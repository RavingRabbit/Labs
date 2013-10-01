object Form1: TForm1
  Left = 215
  Top = 208
  Width = 658
  Height = 420
  Caption = #1055#1086#1083#1085#1099#1081' '#1087#1077#1088#1077#1073#1086#1088
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 256
    Top = 88
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object Label2: TLabel
    Left = 256
    Top = 144
    Width = 30
    Height = 13
    Caption = 'Wmax'
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 225
    Height = 329
    ColCount = 3
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    ColWidths = (
      64
      64
      64)
  end
  object Edit1: TEdit
    Left = 256
    Top = 112
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 256
    Top = 160
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object Button1: TButton
    Left = 280
    Top = 200
    Width = 75
    Height = 25
    Caption = #1056#1072#1089#1089#1095#1080#1090#1072#1090#1100
    TabOrder = 3
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 408
    Top = 8
    Width = 177
    Height = 329
    Lines.Strings = (
      'Memo1')
    TabOrder = 4
  end
end
