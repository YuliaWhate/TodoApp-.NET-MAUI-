using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.ViewModels
{
    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
    public class TodoItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly TodoItem _todoItem;
        private readonly DatabaseService _databaseService;

        public TodoItemViewModel(TodoItem todoItem)
        {
            _todoItem = todoItem;
            _databaseService = App.Current.databaseService;
        }

        public string Title
        {
            get => _todoItem.Title;
            set
            {
                _todoItem.Title = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => _todoItem.Description;
            set
            {
                _todoItem.Description = value;
                OnPropertyChanged();
            }
        }
        //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
        public bool IsCompleated
        {
            get => _todoItem.IsCompleated; 
            set
            {
                _todoItem.IsCompleated = value;
                OnPropertyChanged();
            }      
        }

        public async Task SaveTodoItemAsync()
        {
            await _databaseService.UpdateTodoItemAsync(_todoItem);
        }

        public async Task DeleteTodoItemAsync()
        {
            await _databaseService.DeleteTodoItemAsync(_todoItem);
        }
    }
}
