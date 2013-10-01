object Form1: TForm1
  Left = 192
  Top = 124
  Width = 360
  Height = 343
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -13
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 16
  object lbl1: TLabel
    Left = 48
    Top = 56
    Width = 17
    Height = 16
    Caption = 'N='
  end
  object lbl2: TLabel
    Left = 72
    Top = 128
    Width = 15
    Height = 16
    Caption = 'x='
  end
  object strngrd1: TStringGrid
    Left = 8
    Top = 8
    Width = 328
    Height = 45
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object edt1: TEdit
    Left = 72
    Top = 56
    Width = 113
    Height = 24
    TabOrder = 1
    Text = 'edt1'
  end
  object btn1: TButton
    Left = 192
    Top = 56
    Width = 75
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    TabOrder = 2
    OnClick = btn1Click
  end
  object btn2: TButton
    Left = 48
    Top = 88
    Width = 220
    Height = 25
    Caption = #1047#1072#1087#1086#1083#1085#1080#1090#1100' '#1089#1083#1091#1095#1072#1081#1085#1099#1084#1080' '#1079#1085#1072#1095#1077#1085#1080#1103#1084#1080
    TabOrder = 3
    OnClick = btn2Click
  end
  object mmo1: TMemo
    Left = 8
    Top = 192
    Width = 329
    Height = 105
    Lines.Strings = (
      'mmo1')
    ScrollBars = ssVertical
    TabOrder = 4
  end
  object btn3: TButton
    Left = 48
    Top = 160
    Width = 220
    Height = 25
    Caption = #1056#1072#1089#1089#1095#1080#1090#1072#1090#1100' '#1079#1085#1072#1095#1077#1085#1080#1077' '#1087#1086#1083#1080#1085#1086#1084#1072
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = btn3Click
  end
  object edt2: TEdit
    Left = 96
    Top = 128
    Width = 121
    Height = 24
    TabOrder = 6
    Text = 'edt2'
  end
end
