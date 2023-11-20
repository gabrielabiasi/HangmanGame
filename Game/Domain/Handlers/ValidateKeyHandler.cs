using Game.Domain.Commands;
using Game.Domain.Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Handlers
{
    public class ValidateKeyHandler
    {
        public ResponseCommand Validate(GameCommand keyPressed)
        {
            var word = keyPressed.Word.ToLower();
            var key = keyPressed.Key.ToLower();
            

            var allKeysPressed = keyPressed.WrongKeys.Concat(keyPressed.CorrectKeys).ToList();

            if (allKeysPressed.Contains(keyPressed.Key))
            {
                 return new ResponseCommand(keyPressed.CorrectKeys, keyPressed.WrongKeys, MessagesConstants.KeyPressed);
            }

            if (word.Contains(key))
            {
                keyPressed.CorrectKeys = keyPressed.CorrectKeys.Append(key).ToArray();
                return new ResponseCommand(keyPressed.CorrectKeys, keyPressed.WrongKeys, MessagesConstants.CorrectKey); 
            }

            keyPressed.WrongKeys = keyPressed.WrongKeys.Append(key).ToArray();
            return new ResponseCommand(keyPressed.CorrectKeys, keyPressed.WrongKeys, MessagesConstants.WrongKey);
        }
    }
}
