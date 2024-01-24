Module LolliPopsModule



    Function CalcFicaTax(ByVal WeeklyGrossPay As Double) As Double
        'calc fica tax
        Dim dblFicaTax As Double

        Const Fica As Double = 0.076

        dblFicaTax = WeeklyGrossPay * Fica

        Return dblFicaTax
    End Function


    Function CalcFedTax(ByVal WeeklyGrossPay As Double) As Double  'Didn't think constants here made sense because of the dollar amounts + Percents
        'calculate fed tax

        Dim dblFedTax As Double

        Const dbl50to500 As Double = 0.1
        Const dbl501to2500 As Double = 0.15
        Const dbl2501to5000 As Double = 0.2
        Const dbl5001Plus As Double = 0.25

        If WeeklyGrossPay <= 50 Then
            dblFedTax = 0
        Else
            If WeeklyGrossPay > 50 And WeeklyGrossPay <= 500 Then
                dblFedTax = (WeeklyGrossPay - 51) * dbl50to500
            Else
                If WeeklyGrossPay > 500 And WeeklyGrossPay <= 2500 Then
                    dblFedTax = ((WeeklyGrossPay - 500) * dbl501to2500) + 45
                Else
                    If WeeklyGrossPay > 2500 And WeeklyGrossPay <= 5000 Then
                        dblFedTax = ((WeeklyGrossPay - 2500) * dbl2501to5000) + 345
                    Else
                        dblFedTax = ((WeeklyGrossPay - 5000) * dbl5001Plus) + 845
                    End If
                End If
            End If
        End If
        Return dblFedTax
    End Function

    Function CalcNetPay(ByVal WeeklyGrossPay As Double, ByVal FicaTax As Double, ByVal StateTax As Double, ByVal FedTax As Double)
        'calc net pay
        Dim dblNetPay As Double

        dblNetPay = WeeklyGrossPay - FicaTax - StateTax - FedTax

        Return dblNetPay
    End Function

End Module
