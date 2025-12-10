using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Telhai.CS.CsharpCourse._05_WpfLinq.Models;

namespace Telhai.CS.CsharpCourse._05_WpfLinq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Layan Dabbah
    /// 215057191
    /// </summary>
    public partial class MainWindow : Window
    {
        // שירות יצירת השירים (Singleton)
        private readonly ISongService _songService = RandomSongService.Instance;

        // הרשימה שמוצגת כרגע ב-ListBox
        private ObservableCollection<Song> _songs = new ObservableCollection<Song>();

        // עותק של הרשימה המקורית (לשימוש בחיפוש/ShortHits)
        private List<Song> _originalSongs = new List<Song>();

        public MainWindow()
        {
            InitializeComponent();
            SongsListBox.ItemsSource = _songs;
        }

        // ---------- LOAD 50 SONGS ----------

        private void LoadSongs_Click(object sender, RoutedEventArgs e)
        {
            var generated = _songService.GenerateSongs(50);

            _originalSongs = generated.ToList();
            _songs = new ObservableCollection<Song>(_originalSongs);
            SongsListBox.ItemsSource = _songs;

            UpdateStatistics();
        }

        // ---------- DELETE SELECTED ----------

        private void DeleteSong_Click(object sender, RoutedEventArgs e)
        {
            var selectedSong = SongsListBox.SelectedItem as Song;
            if (selectedSong == null)
            {
                MessageBox.Show("Please select a song to delete.");
                return;
            }

            _songs.Remove(selectedSong);
            _originalSongs.RemoveAll(s => s.Id == selectedSong.Id);

            UpdateStatistics();
        }

        // ---------- ADD SONG (MANUAL) ----------

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            string artist = ArtistTextBox.Text.Trim();
            string title = TitleTextBox.Text.Trim();
            string durationText = DurationTextBox.Text.Trim();

            // ולידציה: לא ריק
            if (string.IsNullOrEmpty(artist) ||
                string.IsNullOrEmpty(title) ||
                string.IsNullOrEmpty(durationText))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            // ולידציה: מספר
            if (!double.TryParse(durationText, out double duration))
            {
                MessageBox.Show("Duration must be a number between 1 and 10.");
                return;
            }

            // ולידציה: בטווח 1–10
            if (duration < 1.0 || duration > 10.0)
            {
                MessageBox.Show("Duration must be between 1 and 10 minutes.");
                return;
            }

            var song = new Song
            {
                Id = Guid.NewGuid(),
                Artist = artist,
                Title = title,
                Duration = duration
            };

            _songs.Add(song);
            _originalSongs.Add(song);

            // ניקוי תיבות טקסט
            ArtistTextBox.Clear();
            TitleTextBox.Clear();
            DurationTextBox.Clear();
            ArtistTextBox.Focus();

            UpdateStatistics();
        }

        // ---------- SORT 1 (Duration ↑) ----------

        private void SortAscending_Click(object sender, RoutedEventArgs e)
        {
            if (_songs == null || !_songs.Any())
                return;

            var sorted = _songs.OrderBy(s => s.Duration).ToList();
            _songs = new ObservableCollection<Song>(sorted);
            SongsListBox.ItemsSource = _songs;

            UpdateStatistics();
        }

        // ---------- SORT 2 (Duration ↓) ----------

        private void SortDescending_Click(object sender, RoutedEventArgs e)
        {
            if (_songs == null || !_songs.Any())
                return;

            var sorted = _songs.OrderByDescending(s => s.Duration).ToList();
            _songs = new ObservableCollection<Song>(sorted);
            SongsListBox.ItemsSource = _songs;

            UpdateStatistics();
        }

        // ---------- SHORT HITS (< 3.0 min) ----------

        private void ShortHits_Click(object sender, RoutedEventArgs e)
        {
            if (!_originalSongs.Any())
            {
                MessageBox.Show("No songs loaded.");
                return;
            }

            var shortSongs = _originalSongs
                .Where(s => s.Duration < 3.0)
                .OrderBy(s => s.Duration)
                .ToList();

            _songs = new ObservableCollection<Song>(shortSongs);
            SongsListBox.ItemsSource = _songs;

            UpdateStatistics();
        }

        // ---------- SEARCH (Artist / Title, Case-Insensitive) ----------

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (!_originalSongs.Any())
            {
                MessageBox.Show("No songs loaded.");
                return;
            }

            string query = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                // אם החיפוש ריק – מחזירים את הרשימה המקורית
                _songs = new ObservableCollection<Song>(_originalSongs);
                SongsListBox.ItemsSource = _songs;
                UpdateStatistics();
                return;
            }

            var results = _originalSongs
                .Where(s =>
                    s.Artist.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    s.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            _songs = new ObservableCollection<Song>(results);
            SongsListBox.ItemsSource = _songs;

            UpdateStatistics();
        }

        private void ClearSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Clear();
            _songs = new ObservableCollection<Song>(_originalSongs);
            SongsListBox.ItemsSource = _songs;

            UpdateStatistics();
        }

        // ---------- GROUP BY ARTIST (MSGBOX) ----------

        private void GroupByArtist_Click(object sender, RoutedEventArgs e)
        {
            if (_songs == null || !_songs.Any())
            {
                MessageBox.Show("No songs to group. Load or add songs first.");
                return;
            }

            var groups = _songs
                .GroupBy(s => s.Artist)
                .OrderBy(g => g.Key);

            StringBuilder sb = new StringBuilder();

            foreach (var g in groups)
            {
                int count = g.Count();
                sb.AppendLine($"{g.Key}: {count} song{(count == 1 ? "" : "s")}");
            }

            MessageBox.Show(sb.ToString(), "Songs per Artist");
        }

        // ---------- STATISTICS (LINQ: Sum, Average, Max) ----------

        private void UpdateStatistics()
        {
            if (_songs == null || !_songs.Any())
            {
                TotalDurationTextBlock.Text = "";
                AverageLengthTextBlock.Text = "";
                LongestSongTextBlock.Text = "";
                return;
            }

            double total = _songs.Sum(s => s.Duration);
            double avg = _songs.Average(s => s.Duration);
            var longest = _songs.OrderByDescending(s => s.Duration).First();

            TotalDurationTextBlock.Text = total.ToString("0.00") + " min";
            AverageLengthTextBlock.Text = avg.ToString("0.00") + " min";
            LongestSongTextBlock.Text =
                $"{longest.Title} ({longest.Artist}, {longest.Duration:0.0} min)";
        }
    }
}
