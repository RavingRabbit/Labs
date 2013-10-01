object Form1: TForm1
  Left = 330
  Top = 133
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'18 '#1089#1090'. '#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040#1085#1076#1088#1077#1103' '#1040#1083#1077#1082#1089#1072#1085#1076#1088#1086#1074#1080#1095#1072
  ClientHeight = 249
  ClientWidth = 601
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -15
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 18
  object btn2: TSpeedButton
    Left = 188
    Top = 8
    Width = 23
    Height = 25
    Caption = '+'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clGreen
    Font.Height = -23
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    OnClick = btn2Click
  end
  object btn4: TSpeedButton
    Left = 188
    Top = 40
    Width = 23
    Height = 25
    Caption = '-'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -23
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    OnClick = btn4Click
  end
  object shp1: TShape
    Left = 312
    Top = 183
    Width = 1
    Height = 59
  end
  object lbl1: TLabel
    Left = 328
    Top = 184
    Width = 163
    Height = 19
    Caption = 'The number of entries '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl2: TLabel
    Left = 328
    Top = 216
    Width = 148
    Height = 19
    Caption = 'that begin with      ='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl3: TLabel
    Left = 504
    Top = 184
    Width = 15
    Height = 58
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -48
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object strngrd1: TStringGrid
    Left = 8
    Top = 8
    Width = 175
    Height = 128
    ColCount = 2
    DefaultColWidth = 85
    FixedCols = 0
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing, goTabs]
    ParentFont = False
    TabOrder = 0
  end
  object tv1: TTreeView
    Left = 224
    Top = 8
    Width = 177
    Height = 97
    Indent = 19
    TabOrder = 1
  end
  object btn1: TBitBtn
    Left = 8
    Top = 144
    Width = 177
    Height = 25
    Caption = 'Enter tree'
    TabOrder = 2
    OnClick = btn1Click
    Kind = bkYes
  end
  object btn3: TBitBtn
    Left = 224
    Top = 112
    Width = 177
    Height = 25
    Caption = 'Display tree'
    Enabled = False
    TabOrder = 3
    OnClick = btn3Click
    Kind = bkAll
  end
  object btn5: TBitBtn
    Left = 224
    Top = 144
    Width = 369
    Height = 25
    Caption = 'Delete tree'
    Enabled = False
    TabOrder = 4
    OnClick = btn5Click
    Kind = bkCancel
  end
  object mmo1: TMemo
    Left = 416
    Top = 8
    Width = 177
    Height = 97
    ReadOnly = True
    TabOrder = 5
  end
  object btn6: TBitBtn
    Left = 416
    Top = 112
    Width = 177
    Height = 25
    Caption = 'Display tree (memo)'
    Enabled = False
    TabOrder = 6
    OnClick = btn6Click
    Kind = bkAll
  end
  object btn7: TBitBtn
    Left = 188
    Top = 72
    Width = 23
    Height = 25
    Hint = 'fill in the table'
    Caption = ' '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -1
    Font.Name = 'Kunstler Script'
    Font.Style = []
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 7
    OnClick = btn7Click
    Kind = bkAll
  end
  object btn8: TButton
    Left = 104
    Top = 184
    Width = 81
    Height = 25
    Caption = 'Find'
    Enabled = False
    TabOrder = 8
    OnClick = btn8Click
  end
  object edt1: TEdit
    Left = 8
    Top = 184
    Width = 89
    Height = 26
    TabOrder = 9
    Text = '15'
  end
  object edt2: TEdit
    Left = 8
    Top = 216
    Width = 177
    Height = 26
    ReadOnly = True
    TabOrder = 10
  end
  object edt3: TEdit
    Left = 224
    Top = 184
    Width = 73
    Height = 26
    TabOrder = 11
    Text = '9'
  end
  object btn9: TButton
    Left = 224
    Top = 216
    Width = 73
    Height = 25
    Caption = 'Delete'
    Enabled = False
    TabOrder = 12
    OnClick = btn9Click
  end
  object edt4: TEdit
    Left = 437
    Top = 216
    Width = 25
    Height = 27
    BevelKind = bkSoft
    BevelOuter = bvSpace
    Enabled = False
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    MaxLength = 1
    ParentFont = False
    TabOrder = 13
    OnChange = edt4Change
  end
end
