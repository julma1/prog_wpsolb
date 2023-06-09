﻿using Model;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel
{

    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ModelAbstractApi ModelLayer;
        private int _BallVal = 1;
        private int width;
        private int height;
        private bool _isStopEnabled = false;
        private bool isStartEnabled = false;
        private bool _isAddEnabled = true;
        private bool _isDeleteEnabled = false;
        private int size = 0;
        private IList _balls;
        public ICommand AddCommand { get; }
        public ICommand RunCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainWindowViewModel()
        {
            width = 600;
            height = 480;
            ModelLayer = ModelAbstractApi.CreateApi(width, height);
            StopCommand = new RelayCommand(Stop);
            AddCommand = new RelayCommand(AddBalls);
            RunCommand = new RelayCommand(Start);
            DeleteCommand = new RelayCommand(DeleteBalls);
        }
        public bool isStopEnabled
        {
            get { return _isStopEnabled; }
            set
            {
                _isStopEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool isRunEnabled
        {
            get { return isStartEnabled; }
            set
            {
                isStartEnabled = value;
                RaisePropertyChanged();
            }
        }

        public bool isAddEnabled
        {
            get
            {
                return _isAddEnabled;
            }
            set
            {
                _isAddEnabled = value;

                RaisePropertyChanged();
            }
        }

        public bool isDeleteEnabled
        {
            get
            {
                return _isDeleteEnabled;
            }
            set
            {
                _isDeleteEnabled = value;

                RaisePropertyChanged();
            }
        }

        public int BallVal
        {
            get
            {
                return _BallVal;
            }
            set
            {
                _BallVal = value;
                RaisePropertyChanged();
            }

        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                RaisePropertyChanged();
            }

        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                RaisePropertyChanged();
            }

        }

        private void AddBalls()
        {
            size += BallVal;
            if (size > 0 && size <= 25)
            {
                isRunEnabled = true;
                isDeleteEnabled = true;
                Balls = ModelLayer.Create(BallVal);
                BallVal = 1;
            }

            if (size <= 0)
            {
                size = 0;
                isRunEnabled = false;
                isDeleteEnabled = false;
                BallVal = 1;
            }


            if (size == 25)
            {
                isAddEnabled = false;
                BallVal = 1;
            }
            if (size > 25)
            {
                size -= BallVal;
                BallVal = 25 - size;
            }

        }

        private void DeleteBalls()
        {
            size -= BallVal;
            Balls = ModelLayer.Delete(BallVal);
            if (size >= 0 && size <= 25)
            {
                isRunEnabled = true;
                isAddEnabled = true;

            }

            if (size <= 0)
            {
                size = 0;
                isAddEnabled = true;
                isRunEnabled = false;
                isDeleteEnabled = false;
            }

            BallVal = 1;

        }

        private void Stop()
        {
            isStopEnabled = false;
            isAddEnabled = true;
            isRunEnabled = true;
            isDeleteEnabled = true;
            ModelLayer.Stop();
        }
        private void Start()
        {
            isStopEnabled = true;
            isRunEnabled = false;
            isAddEnabled = false;
            isDeleteEnabled = false;
            ModelLayer.StartMoving();
        }
        public IList Balls
        {
            get => _balls;
            set
            {
                if (value.Equals(_balls))
                {
                    return;
                }

                _balls = value;
                RaisePropertyChanged();
            }
        }
    }
}
