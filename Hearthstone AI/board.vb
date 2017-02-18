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

    Private Sub _populateListBox(zone As List(Of IEntity), objectCollection As ListBox.ObjectCollection)
        For Each entity In zone
            objectCollection.Add(entity.Number & " " & entity.GetTag("CARDID") & " " & entity.GetTag("[NAME"))
        Next
    End Sub
End Class