Public Class frmSalary

    Function ValidateFirstName(ByRef FirstName As String) As Boolean
        'Validating name input
        'Set txtbox to white in case of previous errors-doing this for every txtbox
        txtFirstName.BackColor = Color.White


        If txtFirstName.Text = String.Empty Then
            txtFirstName.BackColor = Color.Yellow
            txtFirstName.Focus()
            MessageBox.Show("Please enter first name.")
            Return False
        Else
            FirstName = txtFirstName.Text
            Return True

        End If

    End Function

    Function ValidateLastName(ByRef LastName As String) As Boolean
        'Validating name input
        txtLastName.BackColor = Color.White


        If txtLastName.Text = String.Empty Then
            txtLastName.BackColor = Color.Yellow
            txtLastName.Focus()
            MessageBox.Show("Please enter Last Name.")
            Return False
        Else
            LastName = txtLastName.Text
            Return True

        End If
    End Function

    Function ValidateSalary(ByRef Salary As Double) As Boolean
        'validating textbox hours worked

        ' set back color to white in case of prior erros
        txtSalary.BackColor = Color.White


        If IsNumeric(txtSalary.Text) Then
            Salary = txtSalary.Text
            If Salary > 0 Then
                Return True
            Else
                txtSalary.BackColor = Color.Yellow
                txtSalary.Focus()
                MessageBox.Show("Please enter Employee's salary.")
                Return False
            End If
        Else
            txtSalary.BackColor = Color.Yellow
            txtSalary.Focus()
            MessageBox.Show("Please enter Employee's Salary.")
            Return False
        End If


    End Function

    Function ValidateInputs(ByRef FirstName As String, ByRef LastName As String, ByRef salary As Double) As Boolean
        'validating all inputs together

        If ValidateFirstName(FirstName) = True Then
            If ValidateLastName(LastName) = True Then
                If ValidateSalary(salary) = True Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function



    Function CalculateWeeklyGrossPay(ByVal Salary As Double) As Double
        'calculate weekly gross as salary/52
        Dim dblWeeklyGrossPay As Double
        Const Weeks As Double = 52

        dblWeeklyGrossPay = Salary / Weeks

        Return dblWeeklyGrossPay

    End Function

    Function CalcStateTax(ByVal WeeklyGrossPay As Double) As Double 'Couldn't get this to work in Module so did it separately per form
        'determine State tax

        Dim dblStateTax As Double

        Const OhioTax As Double = 0.065
        Const KentuckyTax As Double = 0.06
        Const IndianaTax As Double = 0.055


        If radOhio.Checked = True Then
            dblStateTax = WeeklyGrossPay * OhioTax
        Else
            If RadKentucky.Checked = True Then
                dblStateTax = WeeklyGrossPay * KentuckyTax
            Else
                If radIndiana.Checked = True Then
                    dblStateTax = WeeklyGrossPay * IndianaTax
                End If
            End If
        End If
        Return dblStateTax

    End Function

    Private Sub Display(ByVal WeeklyGrossPay As Double, ByVal FicaTax As Double, ByVal StateTax As Double, ByVal FedTax As Double, ByVal NetPay As Double)
        'display outputs in listbox

        lstSalary.Items.Add("Weekly Gross Pay" & vbTab & vbTab & "Fica Tax" & vbTab & vbTab & "State  Tax" & vbTab & vbTab & "Fed Tax" & vbTab & vbTab & "Net Pay")
        lstSalary.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
        lstSalary.Items.Add(WeeklyGrossPay.ToString("C") & vbTab & vbTab & FicaTax.ToString("c") & vbTab & vbTab & StateTax.ToString("C") & vbTab & vbTab & vbTab & FedTax.ToString("c") & vbTab & vbTab & NetPay.ToString("c"))
        lstSalary.Items.Add("")
    End Sub



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click


        'Reset Textboxes

        txtFirstName.Clear()
        txtLastName.Clear()
        txtSalary.Clear()
        'Set to Ohio as Company is based in Ohio
        radOhio.Checked = True

    End Sub



    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        'option clear

        btnClear_Click(sender, e)
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        'Variables

        Dim dblStateTax As Double
        Dim dblFicaTax As Double
        Dim dblFedTax As Double
        Dim dblWeeklyGrossPay As Double
        Dim dblSalary As Double
        Dim dblNetPay As Double
        Dim strFirstName As String
        Dim StrLastName As String

        If ValidateInputs(strFirstName, StrLastName, dblSalary) = True Then

            dblWeeklyGrossPay = CalculateWeeklyGrossPay(dblSalary)

            dblStateTax = CalcStateTax(dblWeeklyGrossPay)

            dblFicaTax = CalcFicaTax(dblWeeklyGrossPay)

            dblFedTax = CalcFedTax(dblWeeklyGrossPay)

            dblNetPay = CalcNetPay(dblWeeklyGrossPay, dblFicaTax, dblFedTax, dblStateTax)

            Display(dblWeeklyGrossPay, dblFicaTax, dblStateTax, dblFedTax, dblNetPay)

        End If

    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click
        'option calculate
        btnCalculate_Click(sender, e)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button

        Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'option exit calling exit button
        btnExit_Click(sender, e)
    End Sub
End Class