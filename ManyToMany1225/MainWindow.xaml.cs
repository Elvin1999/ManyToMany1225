using ManyToMany1225.DataAccess;
using ManyToMany1225.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManyToMany1225
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        public async void LoadData()
        {
            List<Student> students = null;
            List<Course> courses = null;
            using (var context=new MyContext())
            {
                students = await context.Students.ToListAsync();
                if(students.Count == 0)
                {
                    await context.Students.AddAsync(new Student
                    {
                        Firstname="John",
                        Lastname="Johnlu"
                    });

                    await context.Students.AddAsync(new Student
                    {
                        Firstname = "Aysel",
                        Lastname = "Mammadova"
                    });

                    await context.Students.AddAsync(new Student
                    {
                        Firstname = "Rafiq",
                        Lastname = "Rafiqli"
                    });

                    await context.Students.AddAsync(new Student
                    {
                        Firstname = "Mike",
                        Lastname = "Novruzlu"
                    });

                    await context.Courses.AddAsync(new Course
                    {
                        CourseName = "STEP IT Academy",
                        Address = "Koroglu Rehimov"
                    });

                    await context.Courses.AddAsync(new Course
                    {
                        CourseName = "Elvin Academy",
                        Address = "Port Baku Mall"
                    });

                    await context.SaveChangesAsync();

                    var s1=await context.Students.FirstOrDefaultAsync(s=>s.Id==1);
                    var s2=await context.Students.FirstOrDefaultAsync(s=>s.Id==2);
                    var s3=await context.Students.FirstOrDefaultAsync(s=>s.Id==3);
                    var s4=await context.Students.FirstOrDefaultAsync(s=>s.Id==4);

                    var c1 = await context.Courses.FirstOrDefaultAsync(c => c.Id == 1);
                    var c2 = await context.Courses.FirstOrDefaultAsync(c => c.Id == 2);

                    s1.Courses.Add(c1);

                    s2.Courses.Add(c1);
                    s2.Courses.Add(c2);

                    s3.Courses.Add(c1);
                    s3.Courses.Add(c2);

                    s4.Courses.Add(c2);

                    await context.SaveChangesAsync();
                }


                students = await context.Students.ToListAsync();
                courses=await context.Courses.ToListAsync();

                studentGrid.ItemsSource = students;

                courseGrid.ItemsSource=courses;


            }
        }

        private async void courseGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context=new MyContext())
            {
                try
                {
                    var item = courseGrid.SelectedItem as Course;

                    var course = await context
                        .Courses
                        .Include(nameof(Course.Students))
                        .FirstOrDefaultAsync(c => c.Id == item.Id);

                    if (course != null)
                    {
                        var students = course.Students.ToList();
                        studentGrid.ItemsSource = students;
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        private void studentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
