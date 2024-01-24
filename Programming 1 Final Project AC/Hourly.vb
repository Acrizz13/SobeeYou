'Aleksander Chrismer
'Programming 1 Final
'8/11/22




Public Class frmHourly


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
        'validating name input

        'set back color to white in case of prior errors
        txtLastName.BackColor = Color.White

        If txtLastName.Text = String.Empty Then
            txtLastName.BackColor = Color.Yellow
            txtLastName.Focus()
            MessageBox.Show("Please enter first name.")
            Return False
        Else
            LastName = txtLastName.Text
            Return True

        End If
    End Function



    Function ValidateHoursWorked(ByRef HoursWorked As Double) As Boolean
        'validating textbox hours worked

        'set textbox back color to white in case of prior errors
        txtHoursWorked.BackColor = Color.White


        If IsNumeric(txtHoursWorked.Text) Then
            HoursWorked = txtHoursWorked.Text
            If HoursWorked > 0 Then
                Return True
            Else
                txtHoursWorked.BackColor = Color.Yellow
                txtHoursWorked.Focus()
                MessageBox.Show("Please enter a number larger than 0.")
                Return False
            End If
        Else
            txtHoursWorked.BackColor = Color.Yellow
            txtHoursWorked.Focus()
            MessageBox.Show("Please enter a number larger than 0.")
            Return False
        End If


    End Function

    Function ValidateHourlyWage(ByRef HourlyWage As Double) As Boolean
        'Validating textbox hourly wage

        'set textbox back color to white in case of prior errors
        TxtHourlyWage.BackColor = Color.White

        If IsNumeric(TxtHourlyWage.Text) Then
            HourlyWage = TxtHourlyWage.Text
            If HourlyWage > 0 Then
                Return True
            Else
                TxtHourlyWage.BackColor = Color.Yellow
                TxtHourlyWage.Focus()
                MessageBox.Show("Please enter a number larger than 0.")
                Return False
            End If
        Else
            TxtHourlyWage.BackColor = Color.Yellow
            TxtHourlyWage.Focus()
            MessageBox.Show("Please enter a number larger than 0.")
            Return False
        End If
    End Function

    Function ValidateInputs(ByRef FirstName As String, ByRef LastName As String, ByRef HoursWorked As Double, ByRef HourlyWage As Double) As Boolean
        'Validating inputs
        If ValidateFirstName(FirstName) = True Then
            If ValidateLastName(LastName) = True Then
                If ValidateHoursWorked(HoursWorked) = True Then
                    If ValidateHourlyWage(HourlyWage) = True Then
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
        Else
            Return False
        End If
    End Function







    Function CalcOverTimePay(ByRef HoursWorked As Double, HourlyWage As Double)
        'determining if any over time pay

        Dim dblOvertimePay As Double
        Const OvertimeHourly As Double = 1.5
        If HoursWorked > 40 Then
            dblOvertimePay = (HoursWorked - 40) * (HourlyWage * OvertimeHourly)
        Else
            dblOvertimePay = 0
        End If

        Return dblOvertimePay

    End Function

    Function CalcFortyHourPay(ByVal Hoursworked As Double, ByVal HourlyWage As Double) As Double
        'determine regular pay without overtime
        Dim dblFortyHourpay As Double


        If Hoursworked >= 40 Then
            dblFortyHourpay = (40 * HourlyWage)
        Else
            dblFortyHourpay = HourlyWage * Hoursworked
        End If
        Return dblFortyHourpay


    End Function

    Function CalcWeeklyGrossPay(ByVal FortyHourPay As Double, ByVal OvertimePay As Double)
        'Regular pay + Overtime(if any)

        Dim dblWeeklyGrossPay As Double

        dblWeeklyGrossPay = FortyHourPay + OvertimePay

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





    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'exit button
        Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Reset Textboxes

        txtFirstName.Clear()
        txtLastName.Clear()
        txtHoursWorked.Clear()
        TxtHourlyWage.Clear()
        'Set to Ohio as Company is based in Ohio
        radOhio.Checked = True

    End Sub

    Private Sub Display(ByVal WeeklyGrossPay As Double, ByVal FicaTax As Double, ByVal StateTax As Double, ByVal FedTax As Double, ByVal NetPay As Double)
        'display outputs in listbox

        lstHourly.Items.Add("Weekly Gross Pay" & vbTab & vbTab & "Fica Tax" & vbTab & vbTab & "State  Tax" & vbTab & vbTab & "Fed Tax" & vbTab & vbTab & "Net Pay")
        lstHourly.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
        lstHourly.Items.Add(WeeklyGrossPay.ToString("C") & vbTab & vbTab & vbTab & FicaTax.ToString("c") & vbTab & vbTab & StateTax.ToString("C") & vbTab & vbTab & vbTab & FedTax.ToString("c") & vbTab & vbTab & NetPay.ToString("c"))
        lstHourly.Items.Add("")
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        'option clear

        btnClear_Click(sender, e)
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        'Variables 
        Dim strFirstName As String
        Dim strLastName As String
        Dim dblHoursWorked As Double
        Dim dblHourlyWage As Double
        Dim dblOvertimePay As Double
        Dim dblStateTax As Double
        Dim dblFedTax As Double
        Dim dblWeeklyGrossPay As Double
        Dim dblNetPay As Double
        Dim dblFicaTax As Double
        Dim dblFortyHourPay As Double





        If ValidateInputs(strFirstName, strLastName, dblHoursWorked, dblHourlyWage) = True Then

            'Calculations

            dblOvertimePay = CalcOverTimePay(dblHoursWorked, dblHourlyWage)

            dblFortyHourPay = CalcFortyHourPay(dblHoursWorked, dblHourlyWage)

            dblWeeklyGrossPay = CalcWeeklyGrossPay(dblFortyHourPay, dblOvertimePay)

            'Calc State tax
            dblStateTax = CalcStateTax(dblWeeklyGrossPay)

            'Calc Fica tax
            dblFicaTax = CalcFicaTax(dblWeeklyGrossPay)

            'Calc fed Tax
            dblFedTax = CalcFedTax(dblWeeklyGrossPay)

            'Calc Net Pay
            dblNetPay = CalcNetPay(dblWeeklyGrossPay, dblFicaTax, dblFedTax, dblStateTax)

            'Display
            Display(dblWeeklyGrossPay, dblFicaTax, dblStateTax, dblFedTax, dblNetPay)

        End If
    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click
        'option calculate

        btnCalculate_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'option exit

        btnExit_Click(sender, e)
    End Sub
End Class