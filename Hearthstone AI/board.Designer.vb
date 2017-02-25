<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class board
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.playerHandListBox = New System.Windows.Forms.ListBox()
        Me.GameBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.playerBoardListBox = New System.Windows.Forms.ListBox()
        Me.enemyBoardListBox = New System.Windows.Forms.ListBox()
        Me.enemyHandListBox = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.GameBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'playerHandListBox
        '
        Me.playerHandListBox.FormattingEnabled = True
        Me.playerHandListBox.Location = New System.Drawing.Point(15, 71)
        Me.playerHandListBox.Name = "playerHandListBox"
        Me.playerHandListBox.Size = New System.Drawing.Size(120, 329)
        Me.playerHandListBox.TabIndex = 0
        '
        'GameBindingSource
        '
        Me.GameBindingSource.DataSource = GetType(Hearthstone_AI.game)
        '
        'playerBoardListBox
        '
        Me.playerBoardListBox.FormattingEnabled = True
        Me.playerBoardListBox.Location = New System.Drawing.Point(138, 71)
        Me.playerBoardListBox.Name = "playerBoardListBox"
        Me.playerBoardListBox.Size = New System.Drawing.Size(120, 329)
        Me.playerBoardListBox.TabIndex = 1
        '
        'enemyBoardListBox
        '
        Me.enemyBoardListBox.FormattingEnabled = True
        Me.enemyBoardListBox.Location = New System.Drawing.Point(264, 71)
        Me.enemyBoardListBox.Name = "enemyBoardListBox"
        Me.enemyBoardListBox.Size = New System.Drawing.Size(120, 329)
        Me.enemyBoardListBox.TabIndex = 2
        '
        'enemyHandListBox
        '
        Me.enemyHandListBox.FormattingEnabled = True
        Me.enemyHandListBox.Location = New System.Drawing.Point(390, 71)
        Me.enemyHandListBox.Name = "enemyHandListBox"
        Me.enemyHandListBox.Size = New System.Drawing.Size(120, 329)
        Me.enemyHandListBox.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Player Hand"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Player Board"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(261, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Enemy Board"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(387, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Enemy Hand"
        '
        'board
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 412)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.enemyHandListBox)
        Me.Controls.Add(Me.enemyBoardListBox)
        Me.Controls.Add(Me.playerBoardListBox)
        Me.Controls.Add(Me.playerHandListBox)
        Me.Name = "board"
        Me.Text = "board"
        CType(Me.GameBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents playerHandListBox As ListBox
    Friend WithEvents GameBindingSource As BindingSource
    Friend WithEvents playerBoardListBox As ListBox
    Friend WithEvents enemyBoardListBox As ListBox
    Friend WithEvents enemyHandListBox As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
