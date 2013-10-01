using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SupportTypes;

namespace XonixGame
{
    public interface IContentProvider
    {
        Sprite GetMainDeviceSprite();

        Sprite GetBallSprite(int index);

        Sprite GetAcceleratorSprite();

        Sprite GetLifeBonusSprite();

        Sprite GetScoresBonusSprite();

        Sprite GetTimeBonusSprite();

        Sprite GetExplosionSprite(int index);

        Sprite GetMineSprite();

        Sprite GetDefaultSprite();

        Sprite GetBorderBlockSprite(Point point, int index);

        Sprite GetGroundBlockSprite(Point point, int index);

        Sprite GetWaterBlockSprite(Point point, int index);

        Sprite GetPathBlockSprite(Point point);

        Sprite GetDeadPathBlockSprite(Point point);

        Sprite GetGridSprite(int width, int height);

        Sprite GetBackgroundSprite(int index);

        SpriteFont GetFont(int index);

        Song GetSong(int index);
    }
}