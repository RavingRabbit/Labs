object Form1: TForm1
  Left = 192
  Top = 124
  Width = 386
  Height = 485
  Caption = #1061#1077#1096'-'#1090#1072#1073#1083#1080#1094#1072
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
    Left = 208
    Top = 56
    Width = 42
    Height = 13
    Caption = 'M (<=15)'
  end
  object Label2: TLabel
    Left = 208
    Top = 168
    Width = 26
    Height = 13
    Caption = #1050#1083#1102#1095
  end
  object Label3: TLabel
    Left = 208
    Top = 256
    Width = 91
    Height = 13
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090' '#1087#1086#1080#1089#1082#1072
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 177
    Height = 425
    ColCount = 2
    FixedCols = 0
    RowCount = 16
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    ColWidths = (
      81
      64)
  end
  object Edit1: TEdit
    Left = 208
    Top = 72
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 208
    Top = 104
    Width = 121
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100' '#1093#1077#1096'-'#1090#1072#1073#1083#1080#1094#1091
    TabOrder = 2
    OnClick = Button1Click
  end
  object Edit2: TEdit
    Left = 208
    Top = 184
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'Edit2'
  end
  object Button2: TButton
    Left = 208
    Top = 216
    Width = 121
    Height = 25
    Caption = #1055#1086#1080#1089#1082' '#1087#1086' '#1082#1083#1102#1095#1091
    TabOrder = 4
    OnClick = Button2Click
  end
  object Edit3: TEdit
    Left = 208
    Top = 272
    Width = 121
    Height = 21
    TabOrder = 5
    Text = 'Edit3'
  end
end
