Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class Form1
    Private conn As New MySqlConnection
    Private CMD As MySqlCommand
    Dim CONNECT As MySqlConnection
    Dim CONSTRING As String = "DATA SOURCE = localhost; USERID= root; password= ; DATABASE = experiment1"
    Dim COMMAND As MySqlCommand

    Private Sub Guna2ToggleSwitch1_CheckedChanged_1(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch1.CheckedChanged
        Try
            If Guna2ToggleSwitch1.Checked = True Then
                CONNECT = New MySqlConnection(CONSTRING)
                CONNECT.Open()
                Button2.Enabled = True
                MsgBox("Connected to Database Experiment1", vbInformation, "Confirmation Window")
            Else
                If CONNECT IsNot Nothing AndAlso CONNECT.State = ConnectionState.Open Then
                    CONNECT.Close()
                    Button2.Enabled = False
                    MsgBox("Disconnected from Database Experiment1", vbInformation, "Confirmation Window")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If Not FIRSTNAME.Text = "" Then
                CONNECT = New MySqlConnection(CONSTRING)
                CONNECT.Open()
                Dim SQL As String = "INSERT INTO experiment1 (FIRST_NAME, MIDDLE_NAME, LAST_NAME, NICK_NAME) values ('" & FIRSTNAME.Text & "' , '" & MIDDLENAME.Text & "' , '" & LASTNAME.Text & "', '" & NICKNAME.Text & "')"
                COMMAND = New MySqlCommand(SQL, CONNECT)
                Dim i As Integer = COMMAND.ExecuteNonQuery

                FIRSTNAME.Text = " "
                LASTNAME.Text = " "
                MIDDLENAME.Text = " "
                NICKNAME.Text = " "

                If i <> 0 Then
                    MsgBox("Record Saved", vbInformation, "Admin")
                Else
                    MsgBox("Record Not Saved", vbCritical, "Admin")
                End If
                CONNECT.Close()
            Else
                MsgBox("Invalid")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Button2.Enabled = False
        CONNECT.Close()
        MsgBox("Successfully Connected to Database experiment1", vbInformation, "Confirmation Window")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
    End Sub


End Class