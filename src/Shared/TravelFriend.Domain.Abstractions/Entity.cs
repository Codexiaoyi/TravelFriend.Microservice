using System;
using System.Collections.Generic;
using System.Text;

namespace TravelFriend.Domain.Abstractions
{
    public abstract class Entity : IEntity
    {
        //子类实现
        public abstract object[] GetKeys();

        public override string ToString()
        {
            //重写ToString
            return $"[Entity:{GetType().Name}] Keys = {string.Join("，", GetKeys())}";
        }

    }
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        int? _requestedHashCode;
        /// <summary>
        /// 实体的唯一标识
        /// </summary>
        public TKey Id { get; protected set; }

        /// <summary>
        /// 获取当前实体的标识
        /// </summary>
        /// <returns></returns>
        public override object[] GetKeys()
        {
            return new object[] { Id };
        }

        /// <summary>
        /// 重写Equals判断，用id判断实体是否相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TKey>))
                return false;
            //引用相等那必然相等
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (GetType() != obj.GetType())
                return false;

            Entity<TKey> item = (Entity<TKey>)obj;

            //判断两个实体是否都是可持久化的实体
            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;//使用31异或减少hash值冲突

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        /// <summary>
        /// 表示对象是否是全新创建的，是否是未持久化的
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default);
        }

        public override string ToString()
        {
            return $"[Entity:{GetType().Name}] Id = {Id}";
        }

        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            if (Equals(left, null))
                return Equals(right, null);
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }
}
