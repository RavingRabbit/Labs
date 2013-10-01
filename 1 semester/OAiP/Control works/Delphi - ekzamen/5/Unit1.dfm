object Form1: TForm1
  Left = 192
  Top = 124
  Width = 671
  Height = 362
  Caption = #1052#1077#1090#1086#1076' '#1074#1077#1090#1074#1077#1081' '#1080' '#1075#1088#1072#1085#1080#1094
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
    Left = 264
    Top = 56
    Width = 8
    Height = 13
    Caption = 'N'
  end
  object Label2: TLabel
    Left = 264
    Top = 104
    Width = 30
    Height = 13
    Caption = 'Wmax'
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 217
    Height = 305
    ColCount = 3
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object Memo1: TMemo
    Left = 400
    Top = 8
    Width = 209
    Height = 305
    Lines.Strings = (
      'Memo1')
    TabOrder = 1
  end
  object Button1: TButton
    Left = 280
    Top = 168
    Width = 75
    Height = 25
    Caption = #1056#1072#1089#1089#1095#1080#1090#1072#1090#1100
    TabOrder = 2
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 264
    Top = 72
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 264
    Top = 120
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit2'
  end
end
