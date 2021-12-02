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

            var studentMenu = new ConsoleMenu(args, level: 1)
                .Add("List Students", () => ReadAllStudent())
                .Add("Add Student", () => AddStudent())
                .Add("Update Student", () => UpdateStudent())
                .Add("Delete Student", () => DeleteStudent())
                .Add("Back", ConsoleMenu.Close);

            var classroomMenu = new ConsoleMenu(args, level: 1)
                .Add("List Classrooms", () => ReadAllClassroom())
                .Add("Add Classroom", () => AddClassroom())
                .Add("Update Classroom", () => UpdateClassroom())
                .Add("Delete Classroom", () => DeleteClassroom())
                .Add("Back", ConsoleMenu.Close);

            var teacherMenu = new ConsoleMenu(args, level: 1)
                .Add("List Teachers", () => ReadAllTeacher())
                .Add("Add Teacher", () => AddTeacher())
                .Add("Update Teacher", () => UpdateTeacher())
                .Add("Delete Teacher", () => DeleteTeacher())
                .Add("Back", ConsoleMenu.Close);

            var nonCrudMenu = new ConsoleMenu(args, level: 1)
                .Add("All students average grade", () => StudentAllGradesAvg())
                .Add("Students in the same classroom", () => StudentsInTheSameClassroom())
                .Add("Students with old teacher", () => StudentsWithOldTeacher())
                .Add("Average grades by classroom", () => AvgGradesByClassroom())
                .Add("Total number of classrooms", () => ClassroomCount())
                .Add("Classrooms with young teacher", () => ClassroomsWithYoungTeacher())
                .Add("Classroom with the most students", () => ClassroomWithTheMostStudent())
                .Add("Average age of teachers", () => TeacherAgeAverage())
                .Add("Worst students by teachers", () => WorstStudentsByTeachers())
                .Add("Back", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Students", studentMenu.Show)
                .Add("Classrooms", classroomMenu.Show)
                .Add("Teachers", teacherMenu.Show)
                .Add("Noncruds", nonCrudMenu.Show)
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
            Console.Clear();
            Console.WriteLine("ID\tNAME\t\t\tGRADE\tCLASSROOM_ID");
            var allStudent = rest.Get<Student>("student");
            foreach (var s in allStudent)
            {
                Console.WriteLine($"{s.Id}\t{s.Name}\t\t{Math.Round(s.Grade, 2)}\t{s.ClassroomId}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void AddStudent()
        {
            Console.Clear();
            Console.Write("First name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Grade: ");
            var grade = double.Parse(Console.ReadLine());
            Console.Write("ID of Classroom: ");
            var classroomId = int.Parse(Console.ReadLine());
            rest.Post(new Student() { Name = firstName + " " + lastName, Grade = grade, ClassroomId = classroomId }, "student");
            Console.Clear();
            Console.WriteLine("*** New student successfully created! ***");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void UpdateStudent()
        {
            Console.Clear();
            Console.WriteLine("ID\tNAME\t\t\tGRADE\tCLASSROOM_ID");
            var allStudent = rest.Get<Student>("student");
            foreach (var s in allStudent)
            {
                Console.WriteLine($"{s.Id}\t{s.Name}\t\t{Math.Round(s.Grade, 2)}\t{s.ClassroomId}");
            }
            Console.WriteLine("\nEnter the student's ID you wanna make changes to: ");
            var studentId = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("(new) Name: ");
            var newName = Console.ReadLine();
            Console.Write("(new) Grade: ");
            var newGrade = double.Parse(Console.ReadLine());
            Console.Write("(new) ID of Classroom: ");
            var newClassroomId = int.Parse(Console.ReadLine());
            rest.Put(new Student() { Id = studentId, Name = newName, Grade = newGrade, ClassroomId = newClassroomId }, "student");
            Console.Clear();
            Console.WriteLine("*** Student successfully updated! ***");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void DeleteStudent()
        {
            Console.Clear();
            Console.WriteLine("ID\tNAME\t\t\t\tGRADE\tCLASSROOM_ID");
            var allStudent = rest.Get<Student>("student");
            foreach (var s in allStudent)
            {
                Console.WriteLine($"{s.Id}\t{s.Name}\t\t{Math.Round(s.Grade, 2)}\t{s.ClassroomId}");
            }

            Console.WriteLine("\n\nEnter the ID of the student that you wanna delete: ");
            var deleteId = int.Parse(Console.ReadLine());
            rest.Delete(deleteId, "student");
            Console.Clear();
            Console.WriteLine("*** Student successfully deleted! ***");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        static void ReadAllClassroom()
        {
            Console.Clear();
            Console.WriteLine("ID\tROOM_NUMBER");
            var allClassroom = rest.Get<Classroom>("classroom");
            foreach (var c in allClassroom)
            {
                Console.WriteLine($"{c.Id}\t{c.ClassroomNumber}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void AddClassroom()
        {
            Console.Clear();
            Console.WriteLine("Enter the new classroom's number: ");
            Console.WriteLine("(max. 3 character A - Z, 0 - 9)");
            var classroomNumber = Console.ReadLine();
            rest.Post(new Classroom() { ClassroomNumber = classroomNumber }, "classroom");
            Console.Clear();
            Console.WriteLine("*** New classroom successfully created! ***");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void UpdateClassroom()
        {
            Console.Clear();
            Console.WriteLine("ID\tROOM_NUMBER");
            var allClassroom = rest.Get<Classroom>("classroom");
            foreach (var c in allClassroom)
            {
                Console.WriteLine($"{c.Id}\t{c.ClassroomNumber}");
            }
            Console.WriteLine("\nEnter the classroom's ID you wanna make changes to: ");
            var classroomId = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("(new) Classroom number: ");
            var newClassroomNumber = Console.ReadLine();
            rest.Put(new Classroom() { Id = classroomId, ClassroomNumber = newClassroomNumber }, "classroom");
            Console.Clear();
            Console.WriteLine("*** Classroom successfully updated! ***");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void DeleteClassroom()
        {
            Console.Clear();
            Console.WriteLine("ID\tROOM_NUMBER");
            var allClassroom = rest.Get<Classroom>("classroom");
            foreach (var c in allClassroom)
            {
                Console.WriteLine($"{c.Id}\t{c.ClassroomNumber}");
            }

            Console.WriteLine("\n\nEnter the ID of the classroom that you wanna delete: ");
            var deleteId = int.Parse(Console.ReadLine());
            rest.Delete(deleteId, "classroom");
            Console.Clear();
            Console.WriteLine("*** Classroom successfully deleted! ***");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        static void ReadAllTeacher()
        {
            Console.Clear();
            Console.WriteLine("ID\tNAME\t\t\tAGE\tSUBJECT\t\tCLASSROOM_ID");
            var allTeacher = rest.Get<Teacher>("teacher");
            foreach (var t in allTeacher)
            {
                Console.WriteLine($"{t.Id}\t{t.Name}\t\t{t.Age}\t{t.Subject}\t{t.ClassroomId}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void AddTeacher()
        {
            Console.Clear();
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
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void UpdateTeacher()
        {
            Console.Clear();
            Console.WriteLine("ID\tNAME\t\t\tAGE\tSUBJECT\t\tCLASSROOM_ID");
            var allTeacher = rest.Get<Teacher>("teacher");
            foreach (var t in allTeacher)
            {
                Console.WriteLine($"{t.Id}\t{t.Name}\t\t{t.Age}\t{t.Subject}\t{t.ClassroomId}");
            }
            Console.WriteLine("\nEnter the teacher's ID you wanna make changes to: ");
            var teacherId = int.Parse(Console.ReadLine());
            Console.Clear();
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
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void DeleteTeacher()
        {
            Console.Clear();
            Console.WriteLine("ID\tNAME\t\t\tAGE\tSUBJECT\t\tCLASSROOM_ID");
            var allTeacher = rest.Get<Teacher>("teacher");
            foreach (var t in allTeacher)
            {
                Console.WriteLine($"{t.Id}\t{t.Name}\t\t{t.Age}\t{t.Subject}\t{t.ClassroomId}");
            }

            Console.WriteLine("\n\nEnter the ID of the teacher that you wanna delete: ");
            var deleteId = int.Parse(Console.ReadLine());
            rest.Delete(deleteId, "teacher");
            Console.Clear();
            Console.WriteLine("*** Teacher successfully deleted! ***");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        #endregion

        #region NON-CRUDS
        static void StudentAllGradesAvg()
        {
            Console.Clear();
            var studentsAllGradesAvg = Math.Round(rest.GetSingle<double>("queries/allgradesaverage"), 2);
            Console.WriteLine("\nGrade average of all students: " + studentsAllGradesAvg);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void StudentsWithOldTeacher()
        {
            Console.Clear();
            var studentsStudentsWithOldTeacher = rest.Get<Student>("queries/studentswitholdteacher");
            foreach (var s in studentsStudentsWithOldTeacher)
            {
                Console.WriteLine($"{s.Name}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void StudentsInTheSameClassroom()
        {
            Console.Clear();
            Console.Write("Enter the ID of the classroom you wanna see the students from: ");
            var whichClassroom = int.Parse(Console.ReadLine());
            var studentsStudentsInTheSameClassroom = rest.Get<Student>($"queries/studentsinthesameclassroom/{whichClassroom}");
            foreach (var s in studentsStudentsInTheSameClassroom)
            {
                Console.WriteLine($"{s.Name}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void AvgGradesByClassroom()
        {
            Console.Clear();
            var studentsAvgGradesByClassroom = rest.Get<KeyValuePair<string, double>>("queries/avggradesbyclassroom");
            foreach (var kvp in studentsAvgGradesByClassroom)
            {
                Console.WriteLine($"Classroom: {kvp.Key}\tGrade average: {kvp.Value}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void ClassroomCount()
        {
            Console.Clear();
            var classroomClassroomCount = rest.GetSingle<int>("queries/classroomcount");
            Console.WriteLine($"Total number of classrooms: {classroomClassroomCount}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void ClassroomsWithYoungTeacher()
        {
            Console.Clear();
            var classroomClassroomsWithYoungTeachers = rest.Get<Classroom>("queries/classroomswithyoungteachers");
            Console.WriteLine("Classroomnumber:");
            foreach (var c in classroomClassroomsWithYoungTeachers)
            {
                Console.WriteLine($"{c.ClassroomNumber}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void ClassroomWithTheMostStudent()
        {
            Console.Clear();
            var classroomClassroomWithTheMostStudent = rest.GetSingle<Classroom>("queries/classroomwiththemoststudent");
            Console.WriteLine($"Classroom: {classroomClassroomWithTheMostStudent.ClassroomNumber} - Number of students: {classroomClassroomWithTheMostStudent.Students.Count}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void TeacherAgeAverage()
        {
            Console.Clear();
            var teacherAgeAverage = Math.Round(rest.GetSingle<double>("queries/ageaverage"), 2);
            Console.Write($"Teachers average age: {teacherAgeAverage}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        static void WorstStudentsByTeachers()
        {
            Console.Clear();
            var teacherWorstStudentsByTeachers = rest.Get<KeyValuePair<string, Student>>("queries/worststudentsbyteachers");
            foreach (var kvp in teacherWorstStudentsByTeachers)
            {
                Console.WriteLine($"Teacher's name: {kvp.Key}");
                Console.WriteLine($"Worst student's name: {kvp.Value.Name} - Grade: {kvp.Value.Grade}");
                Console.WriteLine();
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
        #endregion
    }
}
