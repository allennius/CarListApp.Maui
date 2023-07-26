﻿using System;
using CarListApp.Models;
using SQLite;

namespace CarListApp.Services
{
    public class CarService
    {
        SQLiteConnection conn;
        string _dbPath;
        public string StatusMessage;
        int result = 0;

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Car>();
        }

        public List<Car> GetCars()
        {
            try
            {
                Init();
                return conn.Table<Car>().ToList();
            }
            catch (Exception)
            {

                StatusMessage = "Failed to retrieve data.";
            }

            return new List<Car>();
        }

        public void AddCar(Car car)
        {
            try
            {
                Init();

                if (car == null)
                    throw new Exception("Invalid Car Record");

                result = conn.Insert(car);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to insert Data";
            }
        }

        public void UpdateCar(Car car)
        {
            try
            {
                Init();

                if (car == null)
                    throw new Exception("Invalid Car Record");

                result = conn.Update(car);
                StatusMessage = result == 0 ? "Updated Failed" : "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update Data";
            }
        }

        public int DeleteCar(int id)
        {
            try
            {
                Init();

                return conn.Table<Car>().Delete(q => q.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed To Delete object";
            }

            return 0;
        }

        public Car GetCar(int id)
        {
            try
            {
                Init();

                return conn.Table<Car>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retreive Data";
            }

            return null;
        }
    }
}

