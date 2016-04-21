using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Read
{
  public class TextsReader
  {
    public string _Path;
    public Encoding _Enc;

    public TextsReader(string path)
    {
      _Path = path;
      _Enc = Encoding.Default;
    }

    public string ReadFromTextRepository()
    {
      return File.ReadAllText(_Path, _Enc);
    }
  }
}
