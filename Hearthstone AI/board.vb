Public Class board
    Public currentGame As New game

    Public Sub render()
        _clearBoard()
        _populateListBox(currentGame.playerHand, playerHandListBox.Items)
        _populateListBox(currentGame.playerBoard, playerBoardListBox.Items)
        _populateListBox(currentGame.enemyBoard, enemyBoardListBox.Items)
        _populateListBox(currentGame.enemyHand, enemyHandListBox.Items)
    End Sub

    Private Sub _clearBoard()
        playerHandListBox.Items.Clear()
        playerBoardListBox.Items.Clear()
        enemyBoardListBox.Items.Clear()
        enemyHandListBox.Items.Clear()
    End Sub

    Private Sub _populateListBox(zone As List(Of Card), objectCollection As ListBox.ObjectCollection)
        For Each Card In zone
            objectCollection.Add(Card.EntID & " " & cardParser.Entities(Card.EntID).GetTag("CARDID") & " " & cardParser.Entities(Card.EntID).GetTag("[NAME"))
        Next
    End Sub

    Private Sub board_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class