using CZZYLG_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CZZYLG_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Student> Students { get; set; }

        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set 
            { 
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        ClassroomId = value.ClassroomId,
                        Grade = value.Grade
                    };
                    OnPropertyChanged();
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:49692/", "student", "hub");

                CreateStudentCommand = new RelayCommand(() =>
                {
                    Students.Add(new Student()
                    {
                        Name = SelectedStudent.Name,
                        ClassroomId= SelectedStudent.ClassroomId,
                        Grade = SelectedStudent.Grade
                    });
                });

                UpdateStudentCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Students.Update(SelectedStudent);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteStudentCommand = new RelayCommand(() =>
                {
                    Students.Delete(SelectedStudent.Id);
                },
                () =>
                {
                    return SelectedStudent != null;
                });
                SelectedStudent = new Student();
            }
        }
    }
}
