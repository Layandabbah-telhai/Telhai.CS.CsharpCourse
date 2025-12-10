using System.Collections.Generic;
using Telhai.CS.CsharpCourse._05_WpfLinq.Models;

namespace Telhai.CS.CsharpCourse._05_WpfLinq
{
    public interface ISongService
    {
        public List<Song> GenerateSongs(int count);
    }
}
