using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ormico.SqlGoSplitter
{
    public class ScriptSplitter : IEnumerable<string>
    {
        private readonly TextReader _reader;
        private StringBuilder _builder = new StringBuilder();
        private char _current;
        private char _lastChar;
        private ScriptReader _scriptReader;

        public ScriptSplitter(string script)
        {
            _reader = new StringReader(script);
            _scriptReader = new SeparatorLineReader(this);
        }

        internal bool HasNext
        {
            get { return _reader.Peek() != -1; }
        }

        internal char Current
        {
            get { return _current; }
        }

        internal char LastChar
        {
            get { return _lastChar; }
        }

        #region IEnumerable<string> Members

        public IEnumerator<string> GetEnumerator()
        {
            while (Next())
            {
                if (Split())
                {
                    string script = _builder.ToString().Trim();
                    if (script.Length > 0)
                    {
                        yield return (script);
                    }
                    Reset();
                }
            }
            if (_builder.Length > 0)
            {
                string scriptRemains = _builder.ToString().Trim();
                if (scriptRemains.Length > 0)
                {
                    yield return (scriptRemains);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        internal bool Next()
        {
            if (!HasNext)
            {
                return false;
            }

            _lastChar = _current;
            _current = (char)_reader.Read();
            return true;
        }

        internal int Peek()
        {
            return _reader.Peek();
        }

        private bool Split()
        {
            return _scriptReader.ReadNextSection();
        }

        internal void SetParser(ScriptReader newReader)
        {
            _scriptReader = newReader;
        }

        internal void Append(string text)
        {
            _builder.Append(text);
        }

        internal void Append(char c)
        {
            _builder.Append(c);
        }

        void Reset()
        {
            _current = _lastChar = char.MinValue;
            _builder = new StringBuilder();
        }
    }
}