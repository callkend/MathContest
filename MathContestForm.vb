'Kendall Callister
'RCET0265
'Spring 2021
'Math Contest
'


Option Explicit On
Option Strict On

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
        Dim noAnswer As Boolean
        Dim invalidStudent As Boolean
        Dim age As Integer
        Dim grade As Integer
        Dim errorMessage As String = ""
        Dim firstNumber As Integer = CInt(FirstNumberTextBox.Text)
        Dim secondNumber As Integer = CInt(SecondNumberTextBox.Text)
        Dim studentNumber As Integer

        If NameTextBox.Text = "" Then
            nameProblem = True
            errorMessage += "Name is blank "
            NameTextBox.Select()
        End If

        Try
            age = CInt(AgeTextBox.Text)
        Catch ex As Exception
            ageProblem = True
            errorMessage += "Age must contain a number "
            If nameProblem = False Then
                AgeTextBox.Select()
            End If
        End Try

        Try
            grade = CInt(GradeTextBox.Text)
        Catch ex As Exception
            gradeProblem = True
            errorMessage += "Grade must contain a number "
            If nameProblem = False And ageProblem = False Then
                GradeTextBox.Select()
            End If
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

        Try
            studentNumber = CInt(StudentNumberTextBox.Text)
        Catch ex As Exception
            noAnswer = True
            errorMessage += "student hasn't submitted an answer "
            If nameProblem = False And ageProblem = False And gradeProblem = False Then
                StudentNumberTextBox.Select()
            End If
        End Try

        If nameProblem = True Or ageProblem = True Or gradeProblem = True Or noAnswer = True Then
            MessageBox.Show($"The following errors have occurred {errorMessage}")
        ElseIf invalidStudent = True Then
            MessageBox.Show("The Student doesn't qualify for the contest")
        ElseIf AddRadioButton.Checked And studentNumber =
           firstNumber + secondNumber Then
            MessageBox.Show("Correct!!!!")
            CorrectCounter(True, False)
        ElseIf AddRadioButton.Checked And studentNumber <>
            firstNumber + secondNumber Then
            MessageBox.Show($"Incorrect. The correct answer is {firstNumber + secondNumber}")
            CorrectCounter(False, False)
        ElseIf SubtractRadioButton.Checked And studentNumber =
            firstNumber - secondNumber Then
            MessageBox.Show("Correct!!!!")
            CorrectCounter(True, False)
        ElseIf SubtractRadioButton.Checked And studentNumber <>
            firstNumber - secondNumber Then
            MessageBox.Show($"Incorrect. The correct answer is {firstNumber - secondNumber}")
            CorrectCounter(False, False)
        ElseIf MultiplyRadioButton.Checked And studentNumber =
            firstNumber * secondNumber Then
            MessageBox.Show("Correct!!!!")
            CorrectCounter(True, False)
        ElseIf MultiplyRadioButton.Checked And studentNumber <>
            firstNumber * secondNumber Then
            MessageBox.Show($"Incorrect. The correct answer is {firstNumber * secondNumber}")
            CorrectCounter(False, False)
        ElseIf DivideRadioButton.Checked And studentNumber =
            CInt(firstNumber / secondNumber) Then
            MessageBox.Show("Correct!!!!")
            CorrectCounter(True, False)
        ElseIf DivideRadioButton.Checked And studentNumber <>
            CInt(firstNumber / secondNumber) Then
            MessageBox.Show($"Incorrect. The correct answer is {CInt(firstNumber / secondNumber)}")
            CorrectCounter(False, False)
        End If

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Dim correctAndTotal() As Integer = CorrectCounter(True, True)
        NameTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        StudentNumberTextBox.Text = ""
        AddRadioButton.Checked = True
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        Dim correctAndTotal() As Integer = CorrectCounter(False, True)
        MessageBox.Show($"{NameTextBox.Text} got {correctAndTotal(0)} out of {correctAndTotal(1)} correct")
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Function CorrectCounter(correct As Boolean, read As Boolean) As Integer()
        Static correctAndTotal(1) As Integer

        If correct = True And read = False Then
            correctAndTotal(0) += 1
            correctAndTotal(1) += 1
        ElseIf read = False Then
            correctAndTotal(1) += 1
        ElseIf correct = True And read = True Then
            correctAndTotal = {vbEmpty, vbEmpty}
        End If

        FirstNumberTextBox.Text = CStr(CInt(Rnd() * 12))
        SecondNumberTextBox.Text = CStr(CInt(Rnd() * 12))

        Return correctAndTotal
    End Function
End Class
