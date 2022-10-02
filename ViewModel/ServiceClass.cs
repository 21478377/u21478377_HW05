using hw5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace hw5.ViewModel
{
    public class ServiceClass
    {

        //establish instance of class
        private static ServiceClass instance;
        public static ServiceClass getInstance()
        {
            if (instance == null)
            {
                instance = new ServiceClass();
            }
            return instance;
        }

        //establish connection string
        public String connectionString;
        public void setConnectionString(String someConnStr)
        {
            connectionString = someConnStr;
        }

        

        //get borrow viewdata
        public List<BookView> getBorrowDeets(int borrowId)
        {
            List<BookView> bookview = new List<BookView>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from borrows where borrowId = " + borrowId, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            long id = Convert.ToInt64(rdr["borrowId"]);
                            long  bookId = Convert.ToInt64(rdr["bookId"]);
                            long studentId = Convert.ToInt64(rdr["studentId"]);

                            BookView join = new BookView
                            {
                                ID = id,
                                Read = getBooksById((int)bookId),
                                Done = getStudentsById(studentId)
                            };
                            bookview.Add(join);
                        }
                    }
                }
                connection.Close();
            }
            return bookview;
        }

        //index get //get borrow viewdata
        public List<IndexView> GetBooksDeets(int bookId)
        {
            List<IndexView> stuview = new List<IndexView>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from books where bookId = " + bookId, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            long id = Convert.ToInt64(rdr["bookId"]);
                            long authorId = Convert.ToInt64(rdr["authorId"]);
                            long typeId = Convert.ToInt64(rdr["typeId"]);

                            IndexView join = new IndexView
                            {
                                ID = id,
                                Summary = getBooksById(bookId),
                                Title = getAuthorById(authorId),
                                Genre = getTypeById(typeId)
                            };
                            stuview.Add(join);
                        }
                    }
                }
                connection.Close();
            }
            return stuview;
        }



        //pop models

        //authors get
        public Authors getAuthorById(long authorId)
        {
            Authors author = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from author where authorId = " + authorId, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            author = new Authors
                            {
                                authorId = Convert.ToInt32(rdr["authorId"]),
                                name = Convert.ToString(rdr["name"]),
                                surname= Convert.ToString(rdr["surname"])
                            };
                        }
                    }
                }
                connection.Close();
            }
            return author;
        }

        //books get
        public Books getBooksById(int bookId)
        {
            Books books = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from books where bookId = " + bookId, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            books = new Books
                            {
                                bookId = Convert.ToInt32(rdr["bookId"]),
                                name = Convert.ToString(rdr["name"]),
                                pagecount = Convert.ToInt32(rdr["pagecount"]),
                                point = Convert.ToInt32(rdr["point"]),
                                authorId = Convert.ToInt32(rdr["authorId"]),
                                typeId = Convert.ToInt32(rdr["typeId"]),

                            };
                        }
                    }
                }
                connection.Close();
            }
            return books;
        }

        //borrows get
        public Borrows getBorowsById(long borrowId)
        {
            Borrows borrows = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from borrows where borrowId = " + borrowId, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            borrows = new Borrows
                            {
                                borrowId = Convert.ToInt32(rdr["borrowId"]),
                                studentId = Convert.ToInt32(rdr["studentId"]),
                                bookId = Convert.ToInt32(rdr["bookId"]),
                                takenDate = Convert.ToInt32(rdr["takenDate"]),
                                broughtDate = Convert.ToInt32(rdr["broughtDate"]),

                            };
                        }
                    }
                }
                connection.Close();
            }
            return borrows;
        }

        //students get
        public Students getStudentsById(long studentId)
        {
            Students students = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from students where studentId = " + studentId, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            students = new Students
                            {
                                studentId = Convert.ToInt32(rdr["studentId"]),
                                name = Convert.ToString(rdr["name"]),
                                surname = Convert.ToString(rdr["surname"]),
                                birthdate= Convert.ToInt32(rdr["birthdate"]),
                                gender = Convert.ToString(rdr["gender"]),
                                 Class = Convert.ToString(rdr["class"]),
                                 point  = Convert.ToInt32(rdr["point"]),
                            };
                        }
                    }
                }
                connection.Close();
            }
            return students;
        }

        //types get
        public Types getTypeById(long typeId)
        {
            Types types = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from types where typeId = " + typeId, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            types = new Types
                            {
                                typeId = Convert.ToInt32(rdr["typeId"]),
                                name = Convert.ToString(rdr["name"]),

                            };
                        }
                    }
                }
                connection.Close();
            }
            return types;
        }


        //get?? borrowed books
        //get borrow viewdata
        





    }
}


