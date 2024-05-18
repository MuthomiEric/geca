using Shared.Interfaces;

namespace Shared.Models
{
    public class CaterPillar
    {
        private char[,] _map { get; set; }
        private Dictionary<char, List<int>> _body;
        private Stack<ICommand> commandHistory = new Stack<ICommand>();
        private Stack<ICommand> redoHistory = new Stack<ICommand>();
        public CaterPillar(char[,] map)
        {
            _body = new Dictionary<char, List<int>>
            {
                { 'H', new List<int> { 29,0 } },
                { 'T', new List<int> { 29,0 } }
            };
            _map = map;
        }

        public char[,] MoveUp(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (CheckStart())
                {
                    _body['H'][0]--;

                    UpdateHead();

                    UpdateTail();

                    continue;
                }

                RemoveFrom(_body['H'][0], _body['H'][1]);

                _body['H'][0]--;

                UpdateHead();

                RemoveFrom(_body['T'][0], _body['T'][1]);

                _body['T'][0]--;

                UpdateTail();
            }
            return _map;
        }

        public char[,] MoveDown(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (CheckStart())
                {
                    return _map;
                }

                RemoveFrom(_body['H'][0], _body['H'][1]);

                _body['H'][0]++;

                UpdateHead();

                RemoveFrom(_body['T'][0], _body['T'][1]);

                _body['T'][0]--;

                UpdateTail();
            }
            return _map;
        }

        public char[,] MoveLeft(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (CheckStart())
                {
                    return _map;
                }

                RemoveFrom(_body['H'][0], _body['H'][1]);

                _body['H'][1]--;

                UpdateHead();

                _body['T'][1]--;

                UpdateTail();
            }
            return _map;
        }

        public char[,] MoveRight(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                if (CheckStart())
                {
                    _body['H'][1]++;

                    UpdateHead();

                    UpdateTail();

                    continue;
                }

                RemoveFrom(_body['H'][0], _body['H'][1]);

                _body['H'][1]++;

                UpdateHead();

                RemoveFrom(_body['T'][0], _body['T'][1]);

                _body['T'][1]++;

                UpdateTail();
            }
            return _map;
        }

        public void Grow()
        {

        }

        public void Shrink()
        {

        }

        private bool CheckStart()
        {
            if (_body['H'][0] == 29 && _body['H'][1] == 0)
            {
                if (_body['T'][0] == 29 && _body['H'][1] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void UpdateHead()
        {
            _map[_body['H'][0], _body['H'][1]] = 'H';
        }
        private void RemoveFrom(int row, int col)
        {
            _map[row, col] = '*';
        }

        private void UpdateTail()
        {
            PrintStart();

            _map[_body['T'][0], _body['T'][1]] = 'T';
        }
        private void PrintStart()
        {
            _map[29, 0] = 'S';
        }
    }
}
