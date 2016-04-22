using System.IO;
using System.Text;

namespace Replacer.Data
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
