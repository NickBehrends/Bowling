using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bowling.Application;
using Bowling.Application.Queries;
using MediatR;

namespace Bowling.UserInterface.Desktop
{
    public partial class Form1 : Form
    {
        private readonly IMediator _mediator;
        private View _currentState = View.Start;
        private readonly List<string> _playersFromTextBox = new();
        private Guid? _currentGameId = null;

        public Form1(IMediator mediator)
        {
            _mediator = mediator;
            InitializeComponent();
        }

        private async void PlayButton_Click(object sender, EventArgs e)
        {
            var isCurrentGame = await _mediator.Send(new IsThereAnActiveGame.Query());
            if (!isCurrentGame)
                TransitionView(View.NameGame);

        }

        private void GameNameAddAnotherPlayerButton_Click(object sender, EventArgs e)
        {
            _playersFromTextBox.Add(GameNamePlayerTextBox.Text);
            GameNamePlayerTextBox.Clear();
        }

        private async void GameNameButton_Click(object sender, EventArgs e)
        {
            _currentGameId = await _mediator.Send(new CreateGame.Command(GameNameTextBox.Text, _playersFromTextBox));
            TransitionView(View.PlayGame);
        }

        //Please forgive this. Win forms is lovely, isn't it?
        private void TransitionView(View newState)
        {
            switch (_currentState)
            {
                case View.Start:
                    PlayButton.Hide();
                    break;
                case View.NameGame:
                    GameNameLabel.Hide();
                    GameNameButton.Hide();
                    GameNameTextBox.Hide();
                    GameNameInputLabel.Hide();
                    GameNamePlayerTextBox.Hide();
                    GameNamePlayerLabel.Hide();
                    GameNameAddAnotherPlayerButton.Hide();
                    break;
            }

            switch (newState)
            {
                case View.Start:
                    PlayButton.Show();
                    _currentState = View.Start;
                    break;
                case View.NameGame:
                    GameNameLabel.Show();
                    GameNameButton.Show();
                    GameNameTextBox.Show();
                    GameNameInputLabel.Show();
                    GameNamePlayerTextBox.Show();
                    GameNamePlayerLabel.Show();
                    GameNameAddAnotherPlayerButton.Show();
                    _currentState = View.NameGame;
                    break;
            }
        }

        private enum View
        {
            Start,
            NameGame,
            PlayGame
        }
    }
}
