import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { postNewComment } from '../../../Managers/commentManager';

export const CommentModal = ({session, student, teacherId, getAndSetSessions, getAndSetComments}) => {
  const [modal, setModal] = useState(false);
  const [comment, setComment] = useState({
    teacherId: teacherId,
    sessionId: session.id,
    body: ""
  });

  const toggle = () => setModal(!modal);

  const handleSubmit = async (e) => {
    e.preventDefault();
    await postNewComment(comment);
    setComment({teacherId:teacherId, sessionId:session.id, body:""});
    getAndSetSessions();
    getAndSetComments();
    toggle();
  }

  return (
    <div>
        <Button className='comment-btn' color="info" onClick={toggle}>
            Comment
        </Button>
        <Modal className='comment-modal' isOpen={modal} toggle={toggle}>
            <ModalHeader toggle={toggle}>Leave a comment for {student.firstName}</ModalHeader>
            <ModalBody>
                <textarea 
                    className='comment-textarea'
                    placeholder='Comment'
                    value={comment.body}
                    type="text"
                    onChange={(e) => { 
                        const copy = {...comment};
                        copy.body = e.target.value;
                        setComment(copy);
                    }}
                />
            </ModalBody>
            <ModalFooter>
                <Button 
                    color="info" 
                    onClick={(e) => handleSubmit(e)}>
                    Submit
                </Button>{' '}
                <Button color="secondary" onClick={toggle}>
                    Cancel
                </Button>
            </ModalFooter>
        </Modal>
    </div>
  );
}
