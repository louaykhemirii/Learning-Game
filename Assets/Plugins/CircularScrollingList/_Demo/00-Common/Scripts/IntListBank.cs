using System.Collections.Generic;
using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList.Demo
{
    public class IntListBank : BaseListBank
    {
        [SerializeField]
        private int _numOfContents = 10;
        public int startPosition = 0 ;

        private readonly List<int> _contents = new List<int>();
        private readonly IntListContent _contentWrapper = new IntListContent();

        private void Awake()
        {
            for (var i = startPosition; i < _numOfContents+ startPosition; ++i)
                _contents.Add(i + 1);
        }

        public override IListContent GetListContent(int index)
        {
            _contentWrapper.Value = _contents[index];
            return _contentWrapper;
        }

        public override int GetContentCount()
        {
            return _contents.Count;
        }
    }
}
