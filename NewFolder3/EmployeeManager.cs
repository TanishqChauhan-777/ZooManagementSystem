using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ZooManagementSystem
{
    internal class EmployeeManager
    {
        private List<Employee> employes = new List<Employee>();

        private string filepath = "Employee.txt";

        public EmployeeManager()
        {
            LoadEmployeesFromFile();
        }
       private void SaveEmployeeToFile(Employee employee)
        {
            try
            {
                string data =
                    $"{employee.Id}," +
                    $"{employee.Name}," +
                    $"{employee.Age}," +
                    $"{employee.Gender}," +
                    $"{employee.EmployeeRole}," +
                    $"{employee.Salary}," +
                    $"{employee.JoiningDate}," +
                    $"{employee.PhoneNumber}";

                File.AppendAllText(filepath, data + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Error: " + ex.Message);
            }
        }

        private void LoadEmployeesFromFile()
        {
            try
            {
                employes.Clear();

                if (File.Exists(filepath))
                {
                    string[] lines = File.ReadAllLines(filepath);

                    foreach (string line in lines)
                    {
                        string[] data = line.Split(',');

                        Employee employee = new Employee()
                        {
                            Id = Convert.ToInt32(data[0]),
                            Name = data[1],
                            Age = Convert.ToInt32(data[2]),
                            Gender = Enum.Parse<Gender>(data[3]),
                            EmployeeRole = Enum.Parse<EmployeeRole>(data[4]),
                            Salary = Convert.ToDouble(data[5]),
                            JoiningDate = DateTime.Parse(data[6]),
                            PhoneNumber = data[7]
                        };

                        employes.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Loading Error: " + ex.Message);
            }
        }

        private void SaveAllEmployeesToFile()
        {
            try
            {
                File.WriteAllText(filepath, "");

                foreach (Employee emp in employes)
                {
                    SaveEmployeeToFile(emp);
                }

            }
            catch (Exception )
            {
                Console.WriteLine("something Went Wrong.");
            }

        }

        public void AddEmployee()
        {
            Console.WriteLine("========== Add Employee ==========");

            Console.WriteLine();
            int id = InputHelper.ReadInt("Enter Employee Id: ");

            bool found = false;



            foreach (Employee employee in employes)
            {
                if (employee.Id == id) {
                    found = true;
                    break;

                }
            }

            if (found)
            {
                Console.WriteLine("Employee Already Exist");
                return;
            }

            Console.WriteLine();
            string name = InputHelper.ReadString("Enter Employee Name: ");

            Console.WriteLine();
            int age;
            do
            {
                age = InputHelper.ReadInt("Enter Employee Age: ");

                if (age < 0 || age > 100)
                {
                    Console.WriteLine("Invalid Age! Please Try Agian");

                }
            } while (age < 0 || age > 100);

            Console.WriteLine();
            Gender gender = InputHelper.ReadGender();



            Console.WriteLine();
            EmployeeRole Role = InputHelper.ReadEmployeeRole();



            double salary;

            while (true)
            {
                Console.Write("Enter Employee Salary: ");

                if (double.TryParse(Console.ReadLine(), out salary) && salary > 0)
                {
                    break;
                }

                Console.WriteLine("Invalid Salary! Please Enter Again.");
            }


            DateTime joiningDate;

            while (true)
            {
                string input = InputHelper.ReadString("Enter Joining Date (dd/MM/yyyy): ");

                if (DateTime.TryParse(input, out joiningDate))
                {
                    break;
                }

                Console.WriteLine("Invalid Date! Please Try Again.");
            }



            string phoneNumber;

            while (true)
            {
                phoneNumber = InputHelper.ReadString("Enter Phone Number: ");

                if (phoneNumber.Length == 10 &&
                    long.TryParse(phoneNumber, out _))
                {
                    break;
                }

                Console.WriteLine("Invalid Phone Number!");
            }

            Employee employeeData = new Employee()
            {

                Id = id,
                Name = name,
                Age = age,
                Gender = gender,
                EmployeeRole = Role,
                Salary = salary,
                JoiningDate = joiningDate,
                PhoneNumber = phoneNumber



            };

            employes.Add(employeeData);

            SaveEmployeeToFile(employeeData);

            Console.WriteLine();
            Console.WriteLine("Employee Added Succsessfuly!");


        }

        public void DisplayAllEmployee()
        {
            Console.WriteLine("========== All Employees ==========");
            Console.WriteLine();

            if (employes.Count == 0)
            {
                Console.WriteLine("No Employee Found!");
                return;
            }

            foreach (Employee emp in employes)
            {
                Console.WriteLine($"Employee Id:  {emp.Id}");
                Console.WriteLine($"Employee Name:  {emp.Name}");
                Console.WriteLine($"Employee Age:  {emp.Age}");
                Console.WriteLine($"Employee Gender:  {emp.Gender}");
                Console.WriteLine($"Employee Employee Role:  {emp.EmployeeRole}");
                Console.WriteLine($"Employee Employee Salary:  {emp.Salary}");
                Console.WriteLine($"Employee Employee Joining Date:  {emp.JoiningDate}");
                Console.WriteLine($"Employee Employee Phone Number:  {emp.PhoneNumber}");
            }

            }

        public void UpdateEmployee()
        {
            int id = InputHelper.ReadInt("Enter User Id: ");

            Employee employeeToUpdate = null;

            foreach (Employee emp in employes)
            {
                if (emp.Id == id)
                {
                    employeeToUpdate = emp;
                    break;

                }

            }
            if(employeeToUpdate == null)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Employee Found!");

            while (true)

            {
                Console.WriteLine();              
                Console.WriteLine("========== Choose What You Want To Update  ==========");
                Console.WriteLine();

                Console.WriteLine("1. Update Name");
                Console.WriteLine("2. Update Age");
                Console.WriteLine("3. Update Gender");
                Console.WriteLine("4. Update Employee Role");
                Console.WriteLine("5. Update Joining Date");
                Console.WriteLine("6. Update salary ");
                Console.WriteLine("7. Update Phone Number");
                Console.WriteLine("8. Exit & Save");

                int choice = InputHelper.ReadInt("Enter Choice: ");
                Console.WriteLine();


                switch (choice) 
                {
                    case 1:                        
                           string newName = InputHelper.ReadString("Enter New Name: ");
                        employeeToUpdate.Name = newName;
                        Console.WriteLine();
                        Console.WriteLine("Name Updated Successfully!");
                        break;

                    case 2:

                        employeeToUpdate.Age = InputHelper.ReadAge();

                        Console.WriteLine();
                        Console.WriteLine("Age Updated Successfully!");

                        break;

                    case 3:

                        Console.WriteLine();
                        employeeToUpdate.Gender = InputHelper.ReadGender();

                        Console.WriteLine();
                        Console.WriteLine("Gender Updated Successfully!");
                        break;

                    case 4:
                        Console.WriteLine();

                        employeeToUpdate.EmployeeRole = InputHelper.ReadEmployeeRole();

                        Console.WriteLine();
                        Console.WriteLine("Employee Role Updated Successfully!");
                        break;

                    
                    case 5:
                        Console.WriteLine();
                        employeeToUpdate.JoiningDate = InputHelper.ReadJoiningDate();

                        Console.WriteLine();
                        Console.WriteLine("Joining Date Updated Successfully!");
                        break;

                    case 6:
                        {
                            Console.WriteLine();
                            employeeToUpdate.Salary = InputHelper.ReadSalary();

                            Console.WriteLine();
                            Console.WriteLine("Salary Updated Successfully!");
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine();
                            employeeToUpdate.PhoneNumber = InputHelper.ReadPhoneNumber();

                            Console.WriteLine();
                            Console.WriteLine("Phone Number Updated Successfully!");
                            break;
                        }

                    case 8:

                        SaveAllEmployeesToFile();

                        Console.WriteLine();
                        Console.WriteLine("Employee Updated Successfully!");

                        return;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice!");
                        break;
      }
                
            }

        }
        public void DeleteEmployee()
        {
            Employee employeeToDelete = null;

            int id = InputHelper.ReadInt("Enter Eployee Id you Want To delete");

            
            foreach(Employee emp in employes)
            {
                if (emp.Id == id)
                     employeeToDelete = emp;
                break;
            }
            if(employeeToDelete != null)
            {
                employes.Remove(employeeToDelete);

                SaveAllEmployeesToFile();

                Console.WriteLine();
                Console.WriteLine("Employee Deleted Successfully!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found!");
            }
        }

        public void SearchEmployeeByRole()
        {
            Console.WriteLine();

            EmployeeRole role = InputHelper.ReadEmployeeRole();

            bool found = false;

            foreach (Employee employee in employes)
            {
                if (employee.EmployeeRole == role)
                {
                    found = true;

                    Console.WriteLine();
                    Console.WriteLine("========== Employee Details ==========");
                    Console.WriteLine($"Employee Id      : {employee.Id}");
                    Console.WriteLine($"Employee Name    : {employee.Name}");
                    Console.WriteLine($"Employee Age     : {employee.Age}");
                    Console.WriteLine($"Employee Gender  : {employee.Gender}");
                    Console.WriteLine($"Employee Role    : {employee.EmployeeRole}");
                    Console.WriteLine($"Employee Salary  : {employee.Salary}");
                    Console.WriteLine($"Joining Date     : {employee.JoiningDate:dd/MM/yyyy}");
                    Console.WriteLine($"Phone Number     : {employee.PhoneNumber}");
                    Console.WriteLine(new string('-', 40));
                }
            }

            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("No Employees Found With This Role!");
            }
        }

        public void SearchEmployeeByID()
        {
            int id = InputHelper.ReadInt("Enter Employee Id: ");

            bool found = false;

            foreach (Employee employee in employes)
            {
                if (employee.Id == id)
                {
                    found = true;

                    Console.WriteLine();
                    Console.WriteLine("Employee Found!");
                    Console.WriteLine();
                    Console.WriteLine("========== Employee Details ==========");
                    Console.WriteLine($"Employee Id      : {employee.Id}");
                    Console.WriteLine($"Employee Name    : {employee.Name}");
                    Console.WriteLine($"Employee Age     : {employee.Age}");
                    Console.WriteLine($"Employee Gender  : {employee.Gender}");
                    Console.WriteLine($"Employee Role    : {employee.EmployeeRole}");
                    Console.WriteLine($"Employee Salary  : {employee.Salary}");
                    Console.WriteLine($"Joining Date     : {employee.JoiningDate:dd/MM/yyyy}");
                    Console.WriteLine($"Phone Number     : {employee.PhoneNumber}");

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found!");
            }
        }





    }
    }