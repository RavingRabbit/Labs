unit LinkedListException;

interface

uses
      SysUtils;

type
      ELinkedListException = class(Exception)
      public
            constructor Create(const msg: string);
      end;

implementation

constructor ELinkedListException.Create(const msg: string);
begin
      inherited Create(msg);
end;

end.
 