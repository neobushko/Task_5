﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_5.DAL.EF;
using Task_5.DAL.Enteties;
using Task_5.DAL.Interfaces;

namespace Task_5.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private HotelContext hotelContext;
        private CategoryRepository categoryRepository;
        private RoomRepository roomRepository;
        private RecordRepository recordRepository;
        private UserRepository userRepository;
        private PriceforCategoryRepository priceforCategory;


        public UnitOfWork()
        {

        }
        public UnitOfWork(HotelContext context)
        {
            hotelContext = context;
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(hotelContext);
                return categoryRepository;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new RoomRepository(hotelContext);
                return roomRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(hotelContext);
                return userRepository;
            }
        }

        public IRepository<Record> Records
        {
            get
            {
                if (recordRepository == null)
                    recordRepository = new RecordRepository(hotelContext);
                return recordRepository;
            }
        }

        public IRepository<PriceforCategory> PriceforCategories
        {
            get
            {
                if (priceforCategory == null)
                    priceforCategory = new PriceforCategoryRepository(hotelContext);
                return priceforCategory;
            }
        }

        public void Save()
        {
            hotelContext.SaveChanges();
        }
    }
}
