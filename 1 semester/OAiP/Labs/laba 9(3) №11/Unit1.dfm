object Form1: TForm1
  Left = 154
  Top = 140
  Width = 497
  Height = 488
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'9 '#1089#1090'. '#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040'.'#1040'.'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object lbl1: TLabel
    Left = 8
    Top = 376
    Width = 30
    Height = 19
    Caption = 'Xn='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl2: TLabel
    Left = 168
    Top = 376
    Width = 29
    Height = 19
    Caption = 'Xk='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl3: TLabel
    Left = 328
    Top = 376
    Width = 24
    Height = 19
    Caption = 'M='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object btn2: TBitBtn
    Left = 384
    Top = 408
    Width = 89
    Height = 33
    Caption = #1042#1099#1093#1086#1076
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Kind = bkClose
  end
  object pgc1: TPageControl
    Left = 8
    Top = 8
    Width = 465
    Height = 361
    ActivePage = ts1
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object ts1: TTabSheet
      Caption = #1043#1088#1072#1092#1080#1082' Y(x) [Image]'
      object lbl4: TLabel
        Left = 56
        Top = 240
        Width = 110
        Height = 19
        Caption = #1056#1072#1079#1084#1077#1090#1082#1072' '#1086#1089#1077#1081':'
      end
      object lbl5: TLabel
        Left = 176
        Top = 240
        Width = 48
        Height = 19
        Caption = 'Xmin='
      end
      object lbl6: TLabel
        Left = 312
        Top = 232
        Width = 51
        Height = 19
        Caption = 'Xmax='
      end
      object lbl7: TLabel
        Left = 176
        Top = 272
        Width = 49
        Height = 19
        Caption = 'Ymin='
      end
      object lbl8: TLabel
        Left = 312
        Top = 264
        Width = 52
        Height = 19
        Caption = 'Ymax='
      end
      object img1: TImage
        Left = 8
        Top = 0
        Width = 441
        Height = 225
      end
      object edt4: TEdit
        Left = 232
        Top = 232
        Width = 73
        Height = 27
        TabOrder = 0
        Text = 'edt4'
      end
      object edt5: TEdit
        Left = 368
        Top = 232
        Width = 73
        Height = 27
        TabOrder = 1
        Text = 'edt5'
      end
      object edt6: TEdit
        Left = 232
        Top = 264
        Width = 73
        Height = 27
        TabOrder = 2
        Text = 'edt6'
      end
      object edt7: TEdit
        Left = 368
        Top = 264
        Width = 73
        Height = 27
        TabOrder = 3
        Text = 'edt7'
      end
      object btn1: TButton
        Left = 8
        Top = 296
        Width = 153
        Height = 25
        Caption = #1055#1086#1089#1090#1088#1086#1080#1090#1100' '#1075#1088#1072#1092#1080#1082
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Tahoma'
        Font.Style = []
        ParentFont = False
        TabOrder = 4
        OnClick = btn1Click
      end
      object btn5: TButton
        Left = 224
        Top = 296
        Width = 225
        Height = 25
        Caption = #1050#1086#1087#1080#1088#1086#1074#1072#1090#1100' '#1074' '#1073#1091#1092#1077#1088' '#1086#1073#1084#1077#1085#1072
        TabOrder = 5
        OnClick = btn5Click
      end
    end
    object ts3: TTabSheet
      Caption = #1043#1088#1072#1092#1080#1082' Y(x) [Chart]'
      ImageIndex = 2
      object cht1: TChart
        Left = 8
        Top = 8
        Width = 441
        Height = 273
        BackWall.Brush.Color = clWhite
        BackWall.Brush.Style = bsClear
        Title.Text.Strings = (
          'Y(x)')
        Legend.Visible = False
        TabOrder = 0
        object YSeries1: TLineSeries
          Marks.ArrowLength = 8
          Marks.Visible = False
          SeriesColor = clRed
          Pointer.InflateMargins = True
          Pointer.Style = psRectangle
          Pointer.Visible = False
          XValues.DateTime = False
          XValues.Name = 'X'
          XValues.Multiplier = 1.000000000000000000
          XValues.Order = loAscending
          YValues.DateTime = False
          YValues.Name = 'Y'
          YValues.Multiplier = 1.000000000000000000
          YValues.Order = loNone
        end
      end
      object btn3: TButton
        Left = 8
        Top = 296
        Width = 153
        Height = 25
        Caption = #1055#1086#1089#1090#1088#1086#1080#1090#1100' '#1075#1088#1072#1092#1080#1082
        TabOrder = 1
        OnClick = btn3Click
      end
      object btn4: TButton
        Left = 224
        Top = 296
        Width = 225
        Height = 25
        Caption = #1050#1086#1087#1080#1088#1086#1074#1072#1090#1100' '#1074' '#1073#1091#1092#1077#1088' '#1086#1073#1084#1077#1085#1072
        TabOrder = 2
        OnClick = btn4Click
      end
    end
  end
  object pb1: TProgressBar
    Left = 8
    Top = 408
    Width = 369
    Height = 25
    TabOrder = 2
  end
  object edt1: TEdit
    Left = 40
    Top = 376
    Width = 121
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    Text = 'edt1'
  end
  object edt2: TEdit
    Left = 200
    Top = 376
    Width = 121
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    Text = 'edt2'
  end
  object edt3: TEdit
    Left = 352
    Top = 376
    Width = 121
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    Text = 'edt3'
  end
end
