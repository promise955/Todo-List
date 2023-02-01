﻿using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        void save();

    }
}