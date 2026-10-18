using System;
using System.Collections.Generic;

namespace UniversityManagementSystem
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public void DisplayInstructorInfo()
        {
            Console.WriteLine($"Instructor ID: {InstructorId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Specialization: {Specialization}");
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; }

        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            if (course == null)
            {
                return false;
            }

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }
            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            return $"Student ID: {StudentId}, Name: {Name}, Age: {Age}, Enrolled Courses: {Courses.Count}";
        }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Course ID: {CourseId}");
            Console.WriteLine($"Title: {Title}");
            if (Instructor != null)
            {
                Console.WriteLine($"Instructor: {Instructor.Name}");
            }
            else
            {
                Console.WriteLine("Instructor: Not assigned");
            }
        }
    }

    public class studentManagerschool
    {
        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();
        public List<Instructor> instructors = new List<Instructor>();

        public studentManagerschool()
        {
            students = new List<Student>();
            courses = new List<Course>();
            instructors = new List<Instructor>();
        }

        public bool AddStudent(Student student)
        {
            if (student == null)
            {
                return false;
            }

            if (FindStudent(student.StudentId) != null)
            {
                return false;
            }

            students.Add(student);
            return true;
        }

        public bool addCourse(Course course)
        {
            if (course == null)
            {
                return false;
            }

            if (FindCourse(course.CourseId) != null)
            {
                return false;
            }

            courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                return false;
            }
            if (FindInstructor(instructor.InstructorId) != null)
            {
                return false;
            }
            instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            if (students == null)
            {
                return null;
            }
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == studentId)
                {
                    return students[i];
                }
            }
            return null;
        }

        public Course FindCourse(int courseId)
        {
            if (courses == null)
            {
                return null;
            }
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseId == courseId)
                {
                    return courses[i];
                }
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            if (instructors == null)
            {
                return null;
            }
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].InstructorId == instructorId)
                {
                    return instructors[i];
                }
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
            {
                return false;
            }
            return student.Enroll(course);
        }

        public bool IsStudentEnrolledInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);

            if (student == null)
            {
                return false;
            }

            for (int i = 0; i < student.Courses.Count; i++)
            {
                if (student.Courses[i].CourseId == courseId)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetInstructornameByCorseName(string courseName)
        {
            Course course = FindCourseByName(courseName);
            if (course != null && course.Instructor != null)
            {
                return course.Instructor.Name;
            }
            return null;
        }

        public Course FindCourseByName(string title)
        {
            if (title == null || title == "")
            {
                return null;
            }
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return courses[i];
                }
            }
            return null;
        }

        public Student FindStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return students[i];
                }
            }
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            studentManagerschool manager = new studentManagerschool();
            do
            {
                Console.WriteLine("University Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find Student (by ID or Name)");
                Console.WriteLine("9. Find Course (by ID or Name)");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        int sId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Student Name: ");
                        string sName = Console.ReadLine();

                        Console.Write("Enter Student Age: ");
                        int sAge = Convert.ToInt32(Console.ReadLine());

                        Student newStudent = new Student(sId, sName, sAge);

                        bool isadded = manager.AddStudent(newStudent);

                        if (isadded == true)
                        {
                            Console.WriteLine("Student added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add student (ID might already exist).");
                        }

                        break;

                    case "2":
                        Console.Write("Enter Instructor ID: ");
                        int insId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Instructor Name: ");
                        string insName = Console.ReadLine();

                        Console.Write("Enter Instructor Specialization: ");
                        string insSpecialization = Console.ReadLine();

                        Instructor newInstructor = new Instructor(insId, insName, insSpecialization);

                        bool isAdded = manager.AddInstructor(newInstructor);

                        if (isAdded == true)
                        {
                            Console.WriteLine("Instructor added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add instructor (ID might already exist).");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Course ID: ");
                        int cId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course Title: ");
                        string cTitle = Console.ReadLine();
                        Console.Write("Enter Instructor ID for the Course: ");
                        int cInstructorId = Convert.ToInt32(Console.ReadLine());

                        Instructor courseInstructor = manager.FindInstructor(cInstructorId);
                        if (courseInstructor == null)
                        {
                            Console.WriteLine("Instructor not found. Please add the instructor first.");
                            break;
                        }
                        Course newCourse = new Course(cId, cTitle, courseInstructor);
                        bool isCourseAdded = manager.addCourse(newCourse);
                        if (isCourseAdded == true)
                        {
                            Console.WriteLine("Course added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add course (ID might already exist).");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Student ID to enroll: ");
                        int enrollStudentId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course ID to enroll in: ");
                        int enrollCourseId = Convert.ToInt32(Console.ReadLine());

                        bool isEnrolled = manager.EnrollStudentInCourse(enrollStudentId, enrollCourseId);
                        if (isEnrolled == true)
                        {
                            Console.WriteLine("Student enrolled in course successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to enroll student (check if student and course exist, or if already enrolled).");
                        }
                        break;

                    case "5":
                        Console.WriteLine("--- All Students ---");
                        if (manager.students.Count == 0)
                        {
                            Console.WriteLine("No students registered.");
                        }
                        else
                        {
                            for (int i = 0; i < manager.students.Count; i++)
                            {
                                Console.WriteLine(manager.students[i].PrintDetails());
                                Console.WriteLine("-------------------");
                            }
                        }
                        break;

                    case "6":
                        Console.WriteLine("--- All Courses ---");
                        if (manager.courses.Count == 0)
                        {
                            Console.WriteLine("No courses available.");
                        }
                        else
                        {
                            for (int i = 0; i < manager.courses.Count; i++)
                            {
                                manager.courses[i].DisplayCourseInfo();
                                Console.WriteLine("-------------------");
                            }
                        }
                        break;

                    case "7":
                        Console.WriteLine("--- All Instructors ---");
                        if (manager.instructors.Count == 0)
                        {
                            Console.WriteLine("No instructors available.");
                        }
                        else
                        {
                            for (int i = 0; i < manager.instructors.Count; i++)
                            {
                                manager.instructors[i].DisplayInstructorInfo();
                                Console.WriteLine("-------------------");
                            }
                        }
                        break;

                    case "8":
                        Console.WriteLine("Find the student by id or name");
                        Console.WriteLine("1. Find by ID");
                        Console.WriteLine("2. Find by Name");
                        Console.Write("Enter your choice: ");
                        int findChoice = Convert.ToInt32(Console.ReadLine());

                        Student foundStudent = null;

                        if (findChoice == 1)
                        {
                            Console.Write("Enter Student ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            foundStudent = manager.FindStudent(id);
                        }
                        else if (findChoice == 2)
                        {
                            Console.Write("Enter Student Name: ");
                            string name = Console.ReadLine();
                            foundStudent = manager.FindStudentByName(name);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice!");
                        }

                        if (foundStudent != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("--- Student Found ---");
                            Console.WriteLine(foundStudent.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case "9":
                        Console.WriteLine("Find The Course by ID Or Name");
                        Console.WriteLine("1. Find by ID");
                        Console.WriteLine("2. Find by Name");
                        Console.Write("Enter your choice: ");
                        int findCourseChoice = Convert.ToInt32(Console.ReadLine());

                        Course foundCourse = null;

                        if (findCourseChoice == 1)
                        {
                            Console.Write("Enter Course ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            foundCourse = manager.FindCourse(id);
                        }
                        else if (findCourseChoice == 2)
                        {
                            Console.Write("Enter Course Title: ");
                            string title = Console.ReadLine();
                            foundCourse = manager.FindCourseByName(title);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice!");
                        }

                        if (foundCourse != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("--- Course Found ---");
                            foundCourse.DisplayCourseInfo();
                        }
                        else
                        {
                            Console.WriteLine("Course not found.");
                        }
                        break;

                    case "10":
                        Console.WriteLine("Exit!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (true);
        }
    }
}