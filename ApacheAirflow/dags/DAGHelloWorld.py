# Task 1: Create the imports block.
from datetime import timedelta
from airflow import DAG
from airflow.operators.bash import BashOperator
from airflow.operators.python import PythonOperator
from airflow.utils.dates import days_ago

default_args = {
    'owner': 'Zuany',
    'start_date': days_ago(0),
    'email': ['zuany@mail.com'],
    'email_on_failure': False,
    'email_on_retry': False,
    'retries': 1,
    'retry_delay':timedelta(minutes=5),
}

# Create the DAG definition block. The DAG should run daily.
dag = DAG(
    'DAGHelloWorld',
    default_args=default_args,
    description='Test DAG to print Hello World',
    schedule_interval=timedelta(days=1),
)

print_fn = PythonOperator(
    task_id='print_fn',
    python_callable=lambda: print('Hello World'),
    dag=dag,
)

print_fn_2 = PythonOperator(
    task_id='print_fn_2',
    python_callable=lambda: print('Hello World 2'),
    dag=dag,
)

# Create the task pipeline block.
print_fn >> print_fn_2
