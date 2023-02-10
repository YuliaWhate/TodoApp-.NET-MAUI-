using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class TodoItemsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
        private readonly DatabaseService _databaseService;
        private ObservableCollection<TodoItem> _todoItems;

        public TodoItemsViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            _todoItems= new ObservableCollection<TodoItem>();
        }

        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set
            {
                _todoItems = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadTodoItemsAsync()
        {
            TodoItems = new ObservableCollection<TodoItem>(await _databaseService.ReadTodoItemAsync());
        }

        private ObservableCollection<TodoItem> _filteredTodoItems;

        public ObservableCollection<TodoItem> FilteredTodoItems
        {
            get => _filteredTodoItems;
            set
            {
                _filteredTodoItems = value;
                OnPropertyChanged();
            }
        }
        public async Task<ObservableCollection<TodoItem>> SearchTodoItemsAsync(string searchText)
        {
            FilteredTodoItems = new ObservableCollection<TodoItem>(TodoItems.Where(i => i.Title.Contains(searchText)));
            return FilteredTodoItems;
        }
    }
}
