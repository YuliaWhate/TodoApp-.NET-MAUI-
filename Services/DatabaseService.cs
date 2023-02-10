using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TodoApp.Models;

namespace TodoApp.Services
{
    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection conn;
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
        private int _currentId;

        public DatabaseService(string dbpath, SQLiteOpenFlags flags)
        {
            conn = new SQLiteAsyncConnection(dbpath, flags);
            conn.CreateTableAsync<TodoItem>();
        }

        private async Task<int> GetNextId()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                TodoItem todoItemWithMaxId = await conn.Table<TodoItem>().OrderByDescending(x =>
                x.Id).FirstOrDefaultAsync();
                int maxid = todoItemWithMaxId?.Id ?? 0;
                return maxid + 1;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async Task<int> CreateTodoItemAsync(TodoItem todoItem)
        {
            _currentId = await GetNextId();
            todoItem.Id = _currentId;
            return await conn.InsertAsync(todoItem);
        }
        //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
        public async Task<int> UpdateTodoItemAsync(TodoItem todoItem)
        {
            return await conn.UpdateAsync(todoItem);
        }

        public async Task <List<TodoItem>> ReadTodoItemAsync()
        {
            return await conn.Table<TodoItem>().ToListAsync(); 
        }

        public async Task<int> DeleteTodoItemAsync(TodoItem todoItem)
        {
            return await conn.DeleteAsync(todoItem);
        }
    }
}
