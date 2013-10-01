object Form1: TForm1
  Left = 205
  Top = 231
  Width = 710
  Height = 393
  Caption = #1052#1077#1090#1086#1076' '#1084#1080#1085#1080#1084#1072#1083#1100#1085#1086#1075#1086' '#1074#1077#1089#1072
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
    Left = 288
    Top = 80
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object Label2: TLabel
    Left = 288
    Top = 136
    Width = 30
    Height = 13
    Caption = 'Wmax'
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 225
    Height = 313
    ColCount = 3
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object Edit1: TEdit
    Left = 288
    Top = 104
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 288
    Top = 160
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object Memo1: TMemo
    Left = 440
    Top = 8
    Width = 201
    Height = 313
    Lines.Strings = (
      'Memo1')
    TabOrder = 3
  end
  object Button1: TButton
    Left = 296
    Top = 200
    Width = 75
    Height = 25
    Caption = #1056#1072#1089#1089#1095#1080#1090#1072#1090#1100
    TabOrder = 4
    OnClick = Button1Click
  end
end
