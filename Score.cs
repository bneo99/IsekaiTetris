using System;

namespace Tetris
{

    public class Score : IComparable
    {
        private string _name;
        private int _point;
        private Character _character;

        public Score() { }

        public Score(string name, int point, Character character) : this()
        {
            _name = name;
            _point = point;
            _character = character;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public int CompareTo(object obj)
        {
            if (obj is Score)
            {
                Score other = (Score)obj;

                return other.Point - this.Point;
            }
            else
                return 0;
        }
    }
}