using System;

namespace Intarfaces
{
    public interface IClickEvent<T>
    {
        public event Action<T> OnClick;
    }
}