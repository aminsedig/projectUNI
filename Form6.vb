Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class Form6
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Private Sub Userlogin1BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles Userlogin1BindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Userlogin1BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Loginuser1DataSet)

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Loginuser1DataSet.userlogin1' table. You can move, or remove it, as needed.
        Me.Userlogin1TableAdapter.Fill(Me.Loginuser1DataSet.userlogin1)

    End Sub

    Private Sub IDTextBox_TextChanged(sender As Object, e As EventArgs) Handles IDTextBox.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'Change the following to your access database location
        dataFile = "C:\Users\Amin\loginuser1.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString

        'the query:
        Dim cmd As System.Data.OleDb.OleDbCommand = New OleDbCommand("Update  userlogin1 SET Salary =( '" + SalaryTextBox.Text + "') where ID = ('" + IDTextBox.Text + "') ", myConnection)
        If myConnection.State <> ConnectionState.Open Then
            myConnection.Open()
        End If
        cmd.ExecuteNonQuery()

        myConnection.Close()
        MessageBox.Show("You Have Added Salary Successfuly")
        IDTextBox.Text = ""
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        SalaryTextBox.Text = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Show()
        Form1.Refresh()

        Form1.TextBox1.Text = ""
        Form1.TextBox2.Text = ""
    End Sub

    Private Sub SalaryTextBox_TextChanged(sender As Object, e As EventArgs) Handles SalaryTextBox.TextChanged

    End Sub
End Class