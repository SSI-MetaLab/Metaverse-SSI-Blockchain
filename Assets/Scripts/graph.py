import matplotlib.pyplot as plt
import datetime
import numpy as np
import math

values = []
attempts = []

# Use the correct file path. Remember to either double the backslashes or use a raw string literal.
with open(r"C:\Users\ayueb\Desktop\datasetLatency.txt", 'r') as f:
    lines = f.readlines()[1:1001]  # Read only the first 1000 lines and skip the first line
    for attempt, line in enumerate(lines, start=1):  # We use enumerate to count the attempts starting from 1
        # Remove the quotes and newline character, then split the line into timestamp and value
        timestamp_str, value_str = line.strip().strip('"').split(',')
        value = int(value_str)
        values.append(value)
        attempts.append(attempt)

# Removing outliers using IQR
q25, q75 = np.percentile(values, 25), np.percentile(values, 75)
iqr = q75 - q25
cut_off = iqr * 1.5
lower, upper = q25 - cut_off, q75 + cut_off
values_no_outliers = [value for value in values if lower <= value <= upper]
attempts_no_outliers = [attempts[i] for i in range(len(values)) if lower <= values[i] <= upper]

# Create subplots in 2x2 grid
fig, axs = plt.subplots(2, 2, figsize=(10, 10))  # 2 rows, 2 columns

for i in range(4):  # We have four subplots
    start_index = i * 250
    end_index = start_index + 250  # 250 lines for each subplot
    data_slice = values_no_outliers[start_index:end_index]
    attempts_slice = attempts_no_outliers[start_index:end_index]
    mean_slice = np.mean(data_slice)
    
    row = i // 2  # Calculate the subplot's row (integer division by 2)
    col = i % 2   # Calculate the subplot's column (modulo 2)
    axs[row, col].plot(attempts_slice, data_slice, color='blue', linewidth=2)
    axs[row, col].axhline(y=mean_slice, color='darkgreen', linestyle='--')
    axs[row, col].set_xlabel('Attempt')
    axs[row, col].set_ylabel('Time taken to read from Blockchain (ms)')
    axs[row, col].set_title('Latency Test Subplot {}'.format(i+1))  # Title for each subplot
    # Legend for the average
    axs[row, col].text(0.05, 0.95, 'Avg: {:.2f}'.format(mean_slice), color='darkgreen', ha='left', va='top', 
                       transform=axs[row, col].transAxes, 
                       bbox=dict(boxstyle='square,pad=0.3', fc='white', ec='darkgreen', lw=1.2))

plt.tight_layout()  # Adjusts subplot params so that the subplots fit in to the figure area
plt.show()
