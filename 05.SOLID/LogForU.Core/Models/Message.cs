﻿using LogForU.Core.Enums;
using LogForU.Core.Exceptions;
using LogForU.Core.Utils;

namespace LogForU.Core.Models;

public class Message
{
    private string createdTime;
    private string text;

    public Message(string createdTime, string text, ReportLevel reportLevel)
    {
        CreatedTime = createdTime;
        Text = text;
        ReportLevel = reportLevel;
    }

    public string CreatedTime
    {
        get => createdTime;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyCreatedTimeException();
            }

            if (!DateTimeValidator.ValidateDateTimeFormat(value))
            {
                throw new InvalidDateTimeFormatException();
            }

            createdTime = value;
        }
    }

    public string Text
    {
        get => text;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyMessageTextException();
            }

            text = value;
        }
    }

    public ReportLevel ReportLevel { get; private set; }
}
