using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSumOfPath
{
    public class Triangle:ITriangle
    {
        private int[][] _triangleArray = new int[15][];
        private int _maxSum = 0, _tempSum, _arrayValue, _index;
        private List<int> _pathItems = new List<int>();
        private List<int> _tempPathTiems = new List<int>();
        private bool _oddFlag;
     
        private bool _isFullPath;

        public Triangle()
        {
            UploadArray();
        }
    
        private void UploadArray()
        {
            _triangleArray[0] = new int[] { 215 };
            _triangleArray[1] = new int[] { 192, 124 };
            _triangleArray[2] = new int[] { 117, 269, 442 };
            _triangleArray[3] = new int[] { 218, 836, 347, 235 };
            _triangleArray[4] = new int[] { 320, 805, 522, 417, 345 };
            _triangleArray[5] = new int[] { 229, 601, 728, 835, 133, 124 };
            _triangleArray[6] = new int[] { 248, 202, 277, 433, 207, 263, 257 };
            _triangleArray[7] = new int[] { 359, 464, 504, 528, 516, 716, 871, 182 };
            _triangleArray[8] = new int[] { 461, 441, 426, 656, 863, 560, 380, 171, 923 };
            _triangleArray[9] = new int[] { 381, 348, 573, 533, 448, 632, 387, 176,975, 449 };
            _triangleArray[10] = new int[] { 223, 711, 445, 645, 245, 543, 931, 532, 937, 541, 444 };
            _triangleArray[11] = new int[] { 330, 131, 333, 928, 376, 733, 017,778, 839, 168, 197, 197 };
            _triangleArray[12] = new int[] { 131, 171, 522, 137, 217, 224, 291, 413, 528, 520, 227, 229, 928 };
            _triangleArray[13] = new int[] { 223, 626, 034, 683, 839, 052, 627, 310, 713, 999, 629, 817, 410, 121 };
            _triangleArray[14] = new int[] { 924, 622, 911, 233, 325, 139, 721, 218, 253, 223, 107, 233, 230 ,124, 233 };
   
        }  
       
        public void CalculateMaxSumOfPath()
        {          
            var maxPosibilities = (int)Math.Pow(2, GetDimenstionLength() - 1);
           
            for (int i = 0; i <= maxPosibilities; i++)
            {
                ResetBeforeSearch();

                _index = 0;
                for (int j = 0; j < GetDimenstionLength() - 1; j++)
                {
                    _index = _index + (i >> j & 1);
                    _arrayValue = GetValueAt(j + 1, _index);
                    if (IsOdd(GetValueAt(j + 1, _index)) == _oddFlag)
                    {
                        break;
                    }
                    _tempSum += _arrayValue;
                    _tempPathTiems.Add(_arrayValue);
                    if (j == GetDimenstionLength() - 2)
                    {
                        _isFullPath = true;
                    }
                    _oddFlag = !_oddFlag;
                }

                if (_tempSum > _maxSum && _isFullPath)
                {
                    _maxSum = _tempSum;
                    _pathItems = _tempPathTiems.ToList();
                }


            }
        }
        public int GetMaxSum()
        {
            return _maxSum;
        }
        public string GetMaxSumPath()
        {
            return String.Format("Path: {0}", String.Join("->", _pathItems.ToArray()));
        }

        private int GetValueAt(int i, int j)
        {
            return _triangleArray[i][j];
        }
        private int GetDimenstionLength()
        {
            return _triangleArray.Length;
        }
        private bool IsOdd(int val)
        {
            return val % 2 != 0;
        }
        private void ResetBeforeSearch()
        {
            _oddFlag = IsOdd(GetValueAt(0, 0));
            _isFullPath = false;
            _tempPathTiems.Clear();
            _tempSum = GetValueAt(0, 0);
            _tempPathTiems.Add(GetValueAt(0, 0));
        }

    }

}
