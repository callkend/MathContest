Public Class MathContestForm

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        FirstNumberTextBox.Text = CStr(CInt(Rnd() * 12))
        SecondNumberTextBox.Text = CStr(CInt(Rnd() * 12))
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Dim nameProblem As Boolean = False
        Dim ageProblem As Boolean = False
        Dim gradeProblem As Boolean
        Dim invalidStudent As Boolean
        Dim age As Integer
        Dim grade As Integer
        Dim errorMessage As String = ""

        If NameTextBox.Text = "" Then
            nameProblem = True
            errorMessage += "Name is blank "
        End If

        Try
            age = CInt(AgeTextBox.Text)
        Catch ex As Exception
            ageProblem = True
            errorMessage += "Age must contain a number "
        End Try

        Try
            grade = CInt(GradeTextBox.Text)
        Catch ex As Exception
            gradeProblem = True
            errorMessage += "Grade must contain a number "
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

        If nameProblem = True Or ageProblem = True Or gradeProblem = True Then
            MessageBox.Show($"The following errors have occurred {errorMessage}")
        ElseIf AddRadioButton.Checked And CInt(StudentNumberTextBox.text) =
            CInt(FirstNumberTextBox.text) + CInt(SecondNumberTextBox.text) Then
            MessageBox.Show("Correct!!!!")
        ElseIf AddRadioButton.Checked And (StudentNumberTextBox.text) =
            CInt(FirstNumberTextBox.text) + CInt(SecondNumberTextBox.text) Then
        End If

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

End Class
