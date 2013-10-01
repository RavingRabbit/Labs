object Form1: TForm1
  Left = 192
  Top = 124
  Width = 451
  Height = 255
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'17 '#1089#1090'. '#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040#1085#1076#1088#1077#1103' '#1040#1083#1077#1082#1089#1072#1085#1076#1088#1086#1074#1080#1095#1072
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -16
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 19
  object lbl1: TLabel
    Left = 128
    Top = 8
    Width = 23
    Height = 19
    Caption = 'r ='
  end
  object lbl2: TLabel
    Left = 128
    Top = 48
    Width = 108
    Height = 19
    Caption = 'Poland-edition:'
    Visible = False
  end
  object strngrd1: TStringGrid
    Left = 8
    Top = 8
    Width = 111
    Height = 203
    ColCount = 2
    DefaultColWidth = 53
    FixedCols = 0
    RowCount = 8
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing, goTabs]
    ScrollBars = ssVertical
    TabOrder = 0
  end
  object edt1: TEdit
    Left = 160
    Top = 8
    Width = 137
    Height = 27
    TabOrder = 1
    Text = '(d-e)^f*g+s/a+w'
  end
  object edt2: TEdit
    Left = 240
    Top = 48
    Width = 185
    Height = 27
    Hint = 'Poland-edition'
    TabOrder = 2
    Visible = False
  end
  object btn1: TBitBtn
    Left = 304
    Top = 8
    Width = 121
    Height = 25
    Caption = #1054#1087#1086#1083#1103#1095#1080#1090#1100
    TabOrder = 3
    OnClick = btn1Click
    Kind = bkOK
  end
  object btn2: TBitBtn
    Left = 128
    Top = 88
    Width = 297
    Height = 25
    Caption = #1055#1088#1086#1080#1079#1074#1077#1089#1090#1080' '#1088#1072#1089#1089#1095#1105#1090#1099
    Enabled = False
    TabOrder = 4
    OnClick = btn2Click
    Kind = bkAll
  end
  object edt3: TEdit
    Left = 128
    Top = 128
    Width = 297
    Height = 27
    TabOrder = 5
    Text = 'edt3'
    Visible = False
  end
end
