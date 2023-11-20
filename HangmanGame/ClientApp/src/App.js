import React, { useState, useEffect, useCallback } from 'react';
import Header from './components/Header';
import Figure from './components/Figure';
import WrongLetters from './components/WrongLetters';
import Word from './components/Word';
import Popup from './components/Popup';
import Notification from './components/Notification';
import { showNotification as show, checkWin } from './helpers/helpers';
import api from 'axios';

import './App.css';;

function App() {
  const [selectedWord, setSelectedWord] = useState('');
  const [playable, setPlayable] = useState(true);
  const [correctLetters, setCorrectLetters] = useState([]);
  const [wrongLetters, setWrongLetters] = useState([]);
  const [showNotification, setShowNotification] = useState(false);

  const getWord = useCallback(() => {
    api.get('https://localhost:7153/Hangman/word').then((response) => {
      setSelectedWord(response.data);
    });
  }, []);

  useEffect(() => {
    getWord();
  }, [getWord]);

  useEffect(() => {
    const handleKeydown = (event) => {
      const { key, keyCode } = event;
      let responseData = {
        message: '',
        correctKeys: [],
        wrongKeys: [],
      };
      api
        .post('https://localhost:7153/Hangman/key', {
          Key: key,
          KeyCode: keyCode,
          Word: selectedWord,
          CorrectKeys: correctLetters ?? [],
          WrongKeys: wrongLetters ?? [],
        })
        .then((response) => {
          responseData = response.data;

          if (responseData.message === 'Correct key') {
            setCorrectLetters(responseData.correctKeys);
          }

          if (responseData.message === 'Wrong key') {
            setWrongLetters(responseData.wrongKeys);
          }

          if (responseData.message === 'Key already pressed') {
            show(setShowNotification);
          }
        })
        .catch((error) => {
          console.log(error);
        });
    };
    window.addEventListener('keydown', handleKeydown);

    return () => window.removeEventListener('keydown', handleKeydown);
  }, [correctLetters, wrongLetters, playable, selectedWord]);

  const playAgain = useCallback(() => {
    setPlayable(true);

    setCorrectLetters([]);
    setWrongLetters([]);

    getWord();
    
  }, [getWord]);

  return (
    <>
      <Header />
      <div className="game-container">
        <Figure wrongLetters={wrongLetters} />
        <WrongLetters wrongLetters={wrongLetters} />
        <Word selectedWord={selectedWord} correctLetters={correctLetters} />
      </div>
      <Popup
        correctLetters={correctLetters}
        wrongLetters={wrongLetters}
        selectedWord={selectedWord}
        setPlayable={setPlayable}
        playAgain={playAgain}
      />
      <Notification showNotification={showNotification} />
    </>
  );
}

export default App;
