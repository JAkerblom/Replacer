using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Tests
{
  [TestFixture]
  public class ReplacerTest
  {
    private Replacer _repl;

    [SetUp]
    public void setup()
    {

    }

    [Test]
    public void should_replace()
    {
      Assert.AreEqual("this", "this");
    }
  }
}
