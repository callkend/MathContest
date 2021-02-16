Public Class Form1
    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Dim nameProblem As Boolean = False
        Dim ageProblem As Boolean = False
        Dim gradeProblem As Boolean
        Dim invalidStudent As Boolean
        Dim age As Integer
        Dim grade As Integer

        If NameTextBox.Text = "" Then
            nameProblem = True
        End If

        Try
            age = CInt(AgeTextBox.Text)
        Catch ex As Exception
            ageProblem = True
        End Try

        Try
            grade = CInt(GradeTextBox.Text)
        Catch ex As Exception
            gradeProblem = True
        End Try


        Select Case age
            Case < 7
                invalidStudent = True
            Case > 11
                invalidStudent = True
        End Select

        Select Case grade
            Case < 1
                invalidStudent = True
            Case > 4
                invalidStudent = True
        End Select

    End Sub
End Class
