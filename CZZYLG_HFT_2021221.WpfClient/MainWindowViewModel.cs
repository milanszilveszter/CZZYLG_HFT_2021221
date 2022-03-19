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

        #region Students
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
        #endregion

        #region Teachers
        public RestCollection<Teacher> Teachers { get; set; }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                if (value != null)
                {
                    selectedTeacher = new Teacher()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Age = value.Age,
                        Subject = value.Subject,
                        ClassroomId = value.ClassroomId
                    };
                    OnPropertyChanged();
                    (DeleteTeacherCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateTeacherCommand { get; set; }
        public ICommand DeleteTeacherCommand { get; set; }
        public ICommand UpdateTeacherCommand { get; set; }
        #endregion

        #region Classrooms
        public RestCollection<Classroom> Classrooms { get; set; }

        private Classroom selectedClassroom;

        public Classroom SelectedClassroom
        {
            get { return selectedClassroom; }
            set
            {
                if (value != null)
                {
                    selectedClassroom = new Classroom()
                    {
                        Id = value.Id,
                        ClassroomNumber = value.ClassroomNumber
                    };
                    OnPropertyChanged();
                    (DeleteClassroomCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateClassroomCommand { get; set; }
        public ICommand DeleteClassroomCommand { get; set; }
        public ICommand UpdateClassroomCommand { get; set; }
        #endregion

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
                #region Students
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
                #endregion

                #region Teachers
                Teachers = new RestCollection<Teacher>("http://localhost:49692/", "teacher", "hub");

                CreateTeacherCommand = new RelayCommand(() =>
                {
                    Teachers.Add(new Teacher()
                    {
                        Name = SelectedTeacher.Name,
                        Age = SelectedTeacher.Age,
                        Subject = SelectedTeacher.Subject,
                        ClassroomId = SelectedTeacher.ClassroomId
                    });
                });

                UpdateTeacherCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Teachers.Update(SelectedTeacher);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteTeacherCommand = new RelayCommand(() =>
                {
                    Teachers.Delete(SelectedTeacher.Id);
                },
                () =>
                {
                    return SelectedTeacher != null;
                });
                SelectedTeacher = new Teacher();
                #endregion

                #region Classrooms
                Classrooms = new RestCollection<Classroom>("http://localhost:49692/", "classroom", "hub");

                CreateClassroomCommand = new RelayCommand(() =>
                {
                    Classrooms.Add(new Classroom()
                    {
                        ClassroomNumber = SelectedClassroom.ClassroomNumber
                    });
                });

                UpdateClassroomCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Classrooms.Update(SelectedClassroom);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteClassroomCommand = new RelayCommand(() =>
                {
                    Classrooms.Delete(SelectedClassroom.Id);
                },
                () =>
                {
                    return SelectedClassroom != null;
                });
                SelectedClassroom = new Classroom();
                #endregion
            }
        }
    }
}
