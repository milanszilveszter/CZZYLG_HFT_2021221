using ConsoleTools;
using CZZYLG_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace CZZYLG_HFT_2021221.Client
{
    class Program
    {
        static RestService rest = new RestService("http://localhost:49692");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(3000);
            //RestService rest = new RestService("http://localhost:49692");

            #region non-crud
            // STUDENT
            var studentsAllGradesAvg = Math.Round(rest.GetSingle<double>("queries/allgradesaverage"), 2);
            var studentsStudentsWithOldTeacher = rest.Get<Student>("queries/studentswitholdteacher");
            var whichClassroom = 1; //int.Parse(Console.ReadLine());
            var studentsStudentsInTheSameClassroom = rest.Get<Student>($"queries/studentsinthesameclassroom/{whichClassroom}");
            var studentsAvgGradesByClassroom = rest.Get<KeyValuePair<string, double>>("queries/avggradesbyclassroom");

            //// CLASSROOM
            //var classroomClassroomCount = rest.GetSingle<int>("queries/classroomcount");
            //var classroomClassroomsWithYoungTeachers = rest.Get<Classroom>("queries/classroomswithyoungteachers");
            //var classroomClassroomWithTheMostStudent = rest.Get<Classroom>("queries/classroomwiththeMoststudent");

            //// TEACHER
            //var teacherAgeAverage = rest.GetSingle<double>("queries/ageaverage");
            //var teacherWorstStudentsByTeachers = rest.Get<KeyValuePair<string, Student>>("queries/worststudentsbyteachers");
            #endregion

            var studentMenu = new ConsoleMenu(args, level: 1)
                .Add("List Students", () => ReadAllStudent())
                .Add("Add Student", () => AddStudent())
                .Add("Update Student", () => UpdateStudent())
                .Add("Delete Student", () => DeleteStudent())
                .Add("Exit", ConsoleMenu.Close);

            var classroomMenu = new ConsoleMenu(args, level: 1)
                .Add("List Classrooms", () => ReadAllClassroom())
                .Add("Add Classroom", () => AddClassroom())
                .Add("Update Classroom", () => UpdateClassroom())
                .Add("Delete Classroom", () => DeleteClassroom())
                .Add("Exit", ConsoleMenu.Close);

            var teacherMenu = new ConsoleMenu(args, level: 1)
                .Add("List Teachers", () => ReadAllTeacher())
                .Add("Add Teacher", () => AddTeacher())
                .Add("Update Teacher", () => UpdateTeacher())
                .Add("Delete Teacher", () => DeleteTeacher())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Students", studentMenu.Show)
                .Add("Classrooms", classroomMenu.Show)
                .Add("Teachers", teacherMenu.Show)
                //.Add("Noncruds", noncrud_menu.Show)
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = ">> ";
                    config.EnableFilter = false;
                    config.ClearConsole = true;
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = false;
                });

            menu.Show();

        }
        #region CRUDS
        static void ReadAllStudent()
        {
            Console.WriteLine("ID\tNAME\t\t\tGRADE\tCLASSROOM_ID");
            var allStudent = rest.Get<Student>("student");
            foreach (var s in allStudent)
            {
                Console.WriteLine($"{s.Id}\t{s.Name}\t\t{Math.Round(s.Grade, 2)}\t{s.ClassroomId}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void AddStudent()
        {
            Console.Write("First name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Grade: ");
            var grade = double.Parse(Console.ReadLine());
            Console.Write("ID of Classroom: ");
            var classroomId = int.Parse(Console.ReadLine());
            rest.Post(new Student() { Name = firstName+" "+lastName, Grade = grade, ClassroomId = classroomId }, "student");
            Console.Clear();
            Console.WriteLine("*** New student successfully created! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void UpdateStudent()
        {
            Console.WriteLine("Enter the student's ID you wanna make changes to: ");
            var studentId = int.Parse(Console.ReadLine());
            Console.Write("(new) Name: ");
            var newName = Console.ReadLine();
            Console.Write("(new) Grade: ");
            var newGrade = double.Parse(Console.ReadLine());
            Console.Write("(new) ID of Classroom: ");
            var newClassroomId = int.Parse(Console.ReadLine());
            rest.Put(new Student() { Id = studentId, Name = newName, Grade = newGrade, ClassroomId = newClassroomId }, "student");
            Console.Clear();
            Console.WriteLine("*** Student successfully updated! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void DeleteStudent()
        {
            ReadAllStudent();
            Console.WriteLine("\n\nEnter the ID of the student that you wanna delete: ");
            var deleteId = int.Parse(Console.ReadLine());
            rest.Delete(deleteId, "student");
            Console.Clear();
            Console.WriteLine("*** Student successfully deleted! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static void ReadAllClassroom()
        {
            Console.WriteLine("ID\tROOM_NUMBER");
            var allClassroom = rest.Get<Classroom>("classroom");
            foreach (var c in allClassroom)
            {
                Console.WriteLine($"{c.Id}\t{c.ClassroomNumber}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void AddClassroom()
        {
            Console.WriteLine("Enter the new classroom's number: ");
            Console.WriteLine("(max. 3 character A - Z, 0 - 9)");
            var classroomNumber = Console.ReadLine();           
            rest.Post(new Classroom() { ClassroomNumber = classroomNumber }, "classroom");
            Console.Clear();
            Console.WriteLine("*** New classroom successfully created! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void UpdateClassroom()
        {
            Console.WriteLine("Enter the classroom's ID you wanna make changes to: ");
            var classroomId = int.Parse(Console.ReadLine());
            Console.Write("(new) Classroom number: ");
            var newClassroomNumber = Console.ReadLine();     
            rest.Put(new Classroom() { ClassroomNumber = newClassroomNumber }, "classroom");
            Console.Clear();
            Console.WriteLine("*** Classroom successfully updated! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void DeleteClassroom()
        {
            ReadAllClassroom();
            Console.WriteLine("\n\nEnter the ID of the classroom that you wanna delete: ");
            var deleteId = int.Parse(Console.ReadLine());
            rest.Delete(deleteId, "classroom");
            Console.Clear();
            Console.WriteLine("*** Classroom successfully deleted! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static void ReadAllTeacher()
        {
            Console.WriteLine("ID\tNAME\t\tAGE\tSUBJECT\tCLASSROOM_ID");
            var allTeacher = rest.Get<Teacher>("teacher");
            foreach (var t in allTeacher)
            {
                Console.WriteLine($"{t.Id}\t{t.Name}\t\t{t.Age}\t{t.Subject}{t.ClassroomId}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void AddTeacher()
        {
            Console.Write("First name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Age: ");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("Subject: ");
            var subject = Console.ReadLine();
            Console.Write("ID of Classroom: ");
            var classroomId = int.Parse(Console.ReadLine());
            rest.Post(new Teacher() { Name = firstName + " " + lastName, Age = age, Subject = subject, ClassroomId = classroomId }, "teacher");
            Console.Clear();
            Console.WriteLine("*** New teacher successfully created! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void UpdateTeacher()
        {
            Console.WriteLine("Enter the teacher's ID you wanna make changes to: ");
            var teacherId = int.Parse(Console.ReadLine());
            Console.Write("(new) Name: ");
            var newName = Console.ReadLine();
            Console.Write("(new) Age: ");
            var newAge = int.Parse(Console.ReadLine());
            Console.Write("(new) Subject: ");
            var newSubject = Console.ReadLine();
            Console.Write("(new) ID of Classroom: ");
            var newClassroomId = int.Parse(Console.ReadLine());
            rest.Put(new Teacher() { Id = teacherId, Name = newName, Age = newAge, Subject = newSubject, ClassroomId = newClassroomId }, "teacher");
            Console.Clear();
            Console.WriteLine("*** Teacher successfully updated! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static void DeleteTeacher()
        {
            ReadAllStudent();
            Console.WriteLine("\n\nEnter the ID of the teacher that you wanna delete: ");
            var deleteId = int.Parse(Console.ReadLine());
            rest.Delete(deleteId, "teacher");
            Console.Clear();
            Console.WriteLine("*** Teacher successfully deleted! ***");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        #endregion

        #region NON-CRUDS

        #endregion
    }
}
