﻿namespace BulkyBookWeb.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        void save();
    }
}
