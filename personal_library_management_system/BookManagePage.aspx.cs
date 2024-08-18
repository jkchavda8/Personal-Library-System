using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace personal_library_management_system
{
    public partial class BookManagePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBooks();
                BindBorrowedBooks();
            }
        }

        private void BindBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            string query = "SELECT BookID, Title, Author, Genre, ISBN, Quantity FROM Books";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridViewBooks.DataSource = dt;
                        GridViewBooks.DataBind();
                    }
                }
            }
        }

        private void BindBorrowedBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            string query = @"
        SELECT 
            b.BookID,
            f.Name AS FriendName,
            bb.BorrowDate,
            bb.DaysBorrowed
        FROM 
            BorrowedBooks bb
        INNER JOIN 
            Books b ON bb.BookID = b.BookID
        INNER JOIN 
            Friends f ON bb.FriendID = f.FriendID
        WHERE 
            bb.ReturnDate = 0"; // Filtering for books that have not been returned

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridViewBorrowedBooks.DataSource = dt;
                        GridViewBorrowedBooks.DataBind();
                    }
                }
            }
        }


        protected void GridViewBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                int bookID = Convert.ToInt32(e.CommandArgument);
                // Redirect to update page or open a form to update the book
                Response.Redirect($"UpdateBookPage.aspx?BookID={bookID}");
            }
            else if (e.CommandName == "Delete")
            {
                int bookID = Convert.ToInt32(e.CommandArgument);
                DeleteBook(bookID);
            }
        }

        private void DeleteBook(int bookID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString;
            string query = "DELETE FROM Books WHERE BookID = @BookID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookID", bookID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect("BookManagePage.aspx");
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            // Redirect to the add book page or open a form to add a new book
            Response.Redirect("AddBookPage.aspx");
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}
